namespace MyWebAPI;

public class CreateTodoRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? DueTime { get; set; }
}