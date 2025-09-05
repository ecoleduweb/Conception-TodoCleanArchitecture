using CleanTodo.Domain.DTOS;

namespace CleanTodo.Application.UseCase;
public interface IGetAllTodosUseCase
{
    Task<IList<TodoDto>> Execute();
}