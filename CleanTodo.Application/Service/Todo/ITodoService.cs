using CleanTodo.Application.DTOS;

namespace CleanTodo.Application.Service.Todo;

public interface ITodoService
{
    public Task<TodoDto> Create(CreateTodoDto createTodoDto);
    public Task ToggleCompleteStatus(Guid id);
    public Task Delete(Guid id);
    public Task<IList<TodoDto>> GetAll();

}
