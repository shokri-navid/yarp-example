using System.Text.Json;
using System.Text.Json.Serialization;
using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;

namespace MyProxy;

public class AddTodoTransformerProvider : ITransformProvider
{
    public void ValidateRoute(TransformRouteValidationContext context)
    {
    }

    public void ValidateCluster(TransformClusterValidationContext context)
    {
    }

    public void Apply(TransformBuilderContext context)
    {

        if ((context.Route.Metadata?.TryGetValue("CustomTransform", out var value) ?? false)
            && value.Equals(nameof(AddTodoTransformerProvider), StringComparison.InvariantCultureIgnoreCase))
        {
            context.AddRequestTransform(async transformContext =>
            {
                var reader = new StreamReader(transformContext.HttpContext.Request.Body);
                var body = await reader.ReadToEndAsync();
                var dic = JsonSerializer.Deserialize<Dictionary<string, Object>>(body);
                Object val = dic["_title"];
                dic.Remove("_title");
                dic.Add("title", val);
                transformContext.ProxyRequest.Content = JsonContent.Create(dic);
            });
        }
    }
}