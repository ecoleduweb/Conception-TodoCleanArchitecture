using CleanTodo.Application.DTOS;
using CleanTodo.Application.UseCase;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.UseCase;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private CreateTodoUseCase _createUseCase;
    private DeleteTodoUseCase _deleteUseCase;
    private GetAllTodosUseCase _getAllUseCase;
    private GetTodoUseCase _getTodoUseCase;
    private ToggleTodoCompleteStatusUseCase _toggleCompleteStatusUseCase;

    public TodoController(CreateTodoUseCase createTodoUseCase, DeleteTodoUseCase deleteUseCase, GetAllTodosUseCase getAllUseCase, ToggleTodoCompleteStatusUseCase toggleCompleteStatusUseCase, GetTodoUseCase getTodoUseCase)
    {
        _createUseCase = createTodoUseCase;
        _deleteUseCase = deleteUseCase;
        _getAllUseCase = getAllUseCase;
        _getTodoUseCase = getTodoUseCase;
        _toggleCompleteStatusUseCase = toggleCompleteStatusUseCase;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll()
    {
        var todos = await _getAllUseCase.Execute();
        return Ok(todos);
    }

    [HttpPost]
    public async Task<ActionResult<TodoDto>> Create([FromBody] CreateTodoDto createTodoDto)
    {
        TodoDto todo = await _createUseCase.Execute(createTodoDto);

        return CreatedAtAction(
            nameof(Create),
            new { id = todo.Id },
            todo);
    }

    [HttpGet("{id}")] // /api/todo/ton_long_id
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            TodoDto todo = await _getTodoUseCase.Execute(id);
            return Ok(todo);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id)
    {
        try
        {
            await _toggleCompleteStatusUseCase.Execute(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _deleteUseCase.Execute(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}
