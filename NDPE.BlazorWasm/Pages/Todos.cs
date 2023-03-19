using System;
using Microsoft.AspNetCore.Components;
using NDPE.Shared.Models;
using NDPE.Shared.Services;

namespace NDPE.BlazorWasm.Pages
{
    public partial class Todos : ComponentBase
    {

        [Inject]
        public ITodoService todoService { get; set; }

        private IEnumerable<Todo> todos = new List<Todo>();
        public IEnumerable<Todo> _Todos { get => todos; set { todos = value; StateHasChanged(); } }

        protected override async Task OnInitializedAsync()
        {
            await UpdateTodos();
        }

        public async Task UpdateTodos()
        {
            _Todos = await todoService.GetTodosAsync();
            StateHasChanged();
        }

    }
}

