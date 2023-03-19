using System.Net;
using NDPE.Shared.Models;

namespace NDPE.Shared.Services
{
    public interface ITodoService
    {
        HttpStatusCode StatusCode { get; set; }

        Task<Todo?> GetTodoAsync(int id);
        Task<bool> RemoveTodoAsync(int id);
        Task<IEnumerable<Todo>?> GetTodosAsync();
        Task<Todo> InsertTodoAsync(Todo todo);
        Task<bool> UpdateTodoAsync(Todo todo);
    }
}