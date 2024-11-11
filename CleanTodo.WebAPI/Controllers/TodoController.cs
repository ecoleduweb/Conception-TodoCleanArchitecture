using CleanTodo.Application.DTOS;
using CleanTodo.Application.Exceptions;
using CleanTodo.Application.Service.Todo;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll()
    {
        var todos = await _todoService.GetAll();
        return Ok(todos);
    }

    [HttpPost]
    public async Task<ActionResult<TodoDto>> Create([FromBody] CreateTodoDto createTodoDto)
    {
        var todo = await _todoService.Create(createTodoDto);

        return CreatedAtAction(
            nameof(Create),
            new { id = todo.Id },
            todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id)
    {
        try
        {
            await _todoService.ToggleCompleteStatus(id);
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
            await _todoService.Delete(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}
