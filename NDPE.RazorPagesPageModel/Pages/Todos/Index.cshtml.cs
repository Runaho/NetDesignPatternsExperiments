using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NDPE.Shared.Models;
using NDPE.Shared.Services;

namespace NDPE.RazorPagesPageModel.Pages.Todos
{
    /// <summary>
    /// While using asp-handler's and form's with transfering & processing data's with bindings
    /// Your url's will be change like this : Todos?handler=TodoAdd
    /// There is an problem with this approach you shouldn't use history back everythings will be broken becouse
    /// browser can re-send the form data.
    /// There is soo many approach's will fix this problem.
    /// First one form element's can be have id & values (Route Data)
    /// Second whole list can be in one form & onclick send's the clicked id.
    /// Third is Jquery ajax request's on onchange event.
    /// I'm not gonna Demonstrade these versions because frankly, I think these methods are a way around the problem. It's not a real solution.
    /// Unfortunately, RazorPages, like MVC, fails in areas like this where a dynamic component is required.
    /// <summary>
    public class IndexModel : PageModel
    {
        // So hard to find changed element & change & storing the values with requests.
        [BindProperty]
        [Required]
        public IEnumerable<Todo>? Todos { get; set; }

        private ITodoService TodoService { get; }

        public IndexModel(ITodoService todoService)
        {
            TodoService = todoService;
        }

        public async Task OnGetAsync()
        {
            Todos = await TodoService.GetTodosAsync();
        }

        // Passing status with asp-for not convinent via IEnumerable Bindings
        // Becouse you need the find the changed element and update changed element but
        public async Task<IActionResult> OnPostTodoUpdateAsync(int id)
        {
            Todos = await TodoService.GetTodosAsync();
            var todo = Todos.First(f => f.Id == id);

            // Change current status with !
            // While we cannot parse the specifyied array element on dynamicly & we are calculating the value via dynamicly
            // if form request send agein value will changed agein.
            todo.IsComplete = !todo.IsComplete;

            await TodoService.UpdateTodoAsync(todo);

            return Page();
        }

        public async Task<IActionResult> OnPostTodoAddAsync(string todo)
        {
            Todos = await TodoService.GetTodosAsync();
            var newTodo = new Todo { Name = todo, IsComplete = false };
            newTodo = await TodoService.InsertTodoAsync(newTodo);
            Todos = Todos.Append(newTodo);
            return Page();
        }

        public async Task<IActionResult> OnGetTodoDeleteAsync(int id)
        {
            await TodoService.RemoveTodoAsync(id);
            Todos = await TodoService.GetTodosAsync();
            return Page();
        }
    }
}
