namespace MyWebAPI;

public class DataSource : IDataSource
{
    private List<Todo> _todos = new List<Todo>();
    public List<Todo> GetAll()
    {
        return _todos;
    }

    public void AddTodo(Todo todo)
    {
        _todos.Add(todo);
    }
}

public interface IDataSource
{
    List<Todo> GetAll();
    void AddTodo(Todo todo);
}