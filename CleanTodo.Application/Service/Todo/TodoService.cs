using CleanTodo.Application.DTOS;
using CleanTodo.Application.Entities;
using CleanTodo.Application.Service.Todo;
using CleanTodo.Domain.Interfaces;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoDto> Create(CreateTodoDto createTodoDto)
    {
        var todo = new Todo(
            createTodoDto.Title
        );

        var savedTodo = await _todoRepository.Add(todo);

        return new TodoDto(savedTodo);
    }

    public async Task Delete(Guid id)
    {
        await _todoRepository.Delete(id);
    }

    public async Task<IList<TodoDto>> GetAll()
    {
        var todos = await _todoRepository.GetAll();
        return todos.Select(x => new TodoDto(x)).ToList();
    }

    public async Task ToggleCompleteStatus(Guid id)
    {
        await _todoRepository.ToggleCompleteStatus(id);
    }
}