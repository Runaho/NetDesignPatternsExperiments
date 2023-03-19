using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NDPE.Shared.Models;
using NDPE.Shared.Services;

namespace NDPE.RazorPagesPageModel.Pages;

public class TodoTestModel : PageModel
{

    private ITodoService TodoService { get; }

    public TodoTestModel(ITodoService repository)
    {
        TodoService = repository;
    }

    public async Task<IEnumerable<Todo>> Todos() => await TodoService.GetTodosAsync();

    public async Task OnGetAsync()
    {
    }

    public async Task<IActionResult> OnPostAsync(Todo todo)
    {
        if (ModelState.IsValid)
        {
            await TodoService.InsertTodoAsync(todo);
            return RedirectToPage();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostRemoveTodoAsync(int id)
    {
        await TodoService.RemoveTodoAsync(id);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostMarkAsDone(int id, bool isDone)
    {
        var todo = await TodoService.GetTodoAsync(id);
        todo.IsComplete = true;
        await TodoService.UpdateTodoAsync(todo);
        return new EmptyResult();
    }
}
