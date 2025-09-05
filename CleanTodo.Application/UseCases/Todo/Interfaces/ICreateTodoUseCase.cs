using CleanTodo.Application.DTOS;
using CleanTodo.Domain.DTOS;

namespace CleanTodo.Application.UseCase;

public interface ICreateTodoUseCase
{
    Task<TodoDto> Execute(CreateTodoDto createTodoDto);
}