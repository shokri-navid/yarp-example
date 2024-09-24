using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers;
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly IDataSource _dataSource;
    private readonly IHttpContextAccessor _accessor;

    public TodoController(IDataSource dataSource, IHttpContextAccessor accessor)
    {
        _dataSource = dataSource;
        _accessor = accessor;
    }

    [HttpPost]
    public ActionResult<Guid> CreateTodo([FromBody] CreateTodoRequestDto requestDto)
    {
        var todo = new Todo { Title = requestDto.Title, Description = requestDto.Description, DueTime = requestDto.DueTime };
        _dataSource.AddTodo(todo);
        return Ok(todo.Id);
    }
    
    [HttpGet]
    public ActionResult<List<Todo>> GetAllTodo()
    {
        return Ok(_dataSource.GetAll());
    }

}