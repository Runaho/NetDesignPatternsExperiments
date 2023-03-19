using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NDPE.Shared.Models;
using NDPE.Shared.Services;

namespace NDPE.RazorPagesPageModel.Pages.Todos;

public class AddModel : PageModel
{
    [BindProperty, Required]
    public Todo todo { get; set; }
    public ITodoService TodoService { get; }

    public AddModel(ITodoService todoService)
    {
        todo = new Todo();
        TodoService = todoService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Todo insertedTodo = await TodoService.InsertTodoAsync(todo);

        if (TodoService.StatusCode == System.Net.HttpStatusCode.Created)
        {
            return Redirect("/Todos");
        }

        return Page();
    }
}
