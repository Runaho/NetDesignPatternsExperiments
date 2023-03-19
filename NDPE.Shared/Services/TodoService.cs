using System;
using System.Net;
using NDPE.Shared.Helpers;
using NDPE.Shared.Models;

namespace NDPE.Shared.Services;

public class TodoService : ITodoService
{
    private readonly HttpClient _httpClient;
    public HttpStatusCode StatusCode { get; set; }

    public TodoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Todo>?> GetTodosAsync()
    {
        var response = await new ServiceRequestHelper<IEnumerable<Todo>>(_httpClient).GetAsync("todoitems");
        StatusCode = response.Code;

        return response.Value;
    }


    public async Task<Todo?> GetTodoAsync(int id)
    {
        var response = await new ServiceRequestHelper<Todo>(_httpClient).GetAsync($"todoitems/{id}");
        StatusCode = response.Code;

        return response.Value;
    }

    public async Task<bool> UpdateTodoAsync(Todo todo)
    {
        var response = await new ServiceRequestHelper<bool>(_httpClient)
        .SendAsync($"todoitems/{todo.Id}", todo, RequestTypes.Put);

        StatusCode = response.Code;
        return response.Value;
    }


    public async Task<Todo> InsertTodoAsync(Todo todo)
    {
        var response = await new ServiceRequestHelper<Todo>(_httpClient)
        .SendAsync($"todoitems", todo, RequestTypes.Post);

        StatusCode = response.Code;
        return response.Value;
    }



    public async Task<bool> RemoveTodoAsync(int id)
    {
        var response = await new ServiceRequestHelper<bool>(_httpClient).DeleteAsync($"todoitems", id.ToString());
        StatusCode = response.Code;

        return response.Value;
    }
}

