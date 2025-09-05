using CleanTodo.Domain.DTOS;

namespace CleanTodo.Domain.Service.Todo;

public interface ITodoService
{
    public Task<TodoDto> FindById(Guid id);

}
