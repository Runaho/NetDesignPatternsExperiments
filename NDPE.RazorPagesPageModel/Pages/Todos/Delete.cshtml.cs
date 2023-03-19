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

public class DeleteModel : PageModel
{
    [BindProperty, Required]
    public Todo todo { get; set; }
    public ITodoService TodoService { get; }

    public DeleteModel(ITodoService todoService)
    {
        todo = new Todo();
        TodoService = todoService;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        if (id != 0)
        {
            var _todo = await TodoService.GetTodoAsync(id);
            if (_todo != null)
            {
                todo = _todo;
                return Page();
            }
        }

        return Redirect("Index");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        bool UpdateStatus = await TodoService.RemoveTodoAsync(todo.Id);

        if (TodoService.StatusCode == System.Net.HttpStatusCode.OK)
            return Redirect("/todos");

        return Page();
    }
}