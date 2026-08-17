using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCase;

public class ToggleTodoCompleteStatusUseCase
{

    private readonly ITodoRepository _todoRepository;

    public ToggleTodoCompleteStatusUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task Execute(Guid id)
    {
        Todo? todo = await _todoRepository.FindById(id);
        if (todo == null)
        {
            throw new NotFoundException(id);
        }
        await _todoRepository.ToggleCompleteStatus(id);
    }
}