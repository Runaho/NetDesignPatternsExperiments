using System;
using Microsoft.AspNetCore.Mvc;
using NDPE.Shared.Models;
using NDPE.Shared.Services;

namespace NDPE.MVC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoAPIController : ControllerBase
{
    private static IEnumerable<Todo> _todos = new List<Todo>();

    public ITodoService TodoService { get; }

    public TodoAPIController(ITodoService todoService)
    {
        TodoService = todoService;
    }

    [HttpGet]
    public async Task<IEnumerable<Todo>> GetAsync()
    {
        _todos = await TodoService.GetTodosAsync();
        return _todos.OrderBy(o => o.Id);
    }

    [HttpPost]
    public async Task<ActionResult<Todo>> PostAsync([FromBody] Todo todo)
    {
        _todos = await TodoService.GetTodosAsync();

        if (todo == null)
        {
            return BadRequest();
        }

        await TodoService.InsertTodoAsync(todo);
        _todos = await TodoService.GetTodosAsync();


        return _todos.ToList().OrderBy(o=>o.Id).LastOrDefault();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetByIdAsync(int id)
    {
        _todos = await TodoService.GetTodosAsync();
        var todo = _todos.FirstOrDefault(t => t.Id == id);

        if (todo == null)
        {
            return NotFound();
        }

        return todo;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] Todo todo)
    {
        _todos = await TodoService.GetTodosAsync();

        if (todo == null)
        {
            return BadRequest();
        }

        var existingTodo = _todos.FirstOrDefault(t => t.Id == id);

        if (existingTodo == null)
        {
            return NotFound();
        }

        todo.Id = id;
        await TodoService.UpdateTodoAsync(todo);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        _todos = await TodoService.GetTodosAsync();

        var todo = _todos.FirstOrDefault(t => t.Id == id);

        if (todo == null)
        {
            return NotFound();
        }

        await TodoService.RemoveTodoAsync(id);

        return NoContent();
    }
}

