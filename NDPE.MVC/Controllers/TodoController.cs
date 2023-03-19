using System;
using Microsoft.AspNetCore.Mvc;

namespace NDPE.MVC.Controllers;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
}


public class TodoController : Controller
{
    private static List<TodoItem> _todoList = new List<TodoItem>()
    {
        new TodoItem() { Id = 1, Title = "Todo item 1", IsDone = false },
        new TodoItem() { Id = 2, Title = "Todo item 2", IsDone = true },
        new TodoItem() { Id = 3, Title = "Todo item 3", IsDone = false }
    };

    public ActionResult Index()
    {
        return View(_todoList);
    }

    public ActionResult Alpine()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Edit(int id, string title, bool isDone)
    {
        var todoItem = _todoList.FirstOrDefault(t => t.Id == id);
        if (todoItem != null)
        {
            todoItem.Title = title;
            todoItem.IsDone = isDone;
        }
        return Json(new { success = true });
    }

    [HttpPost]
    public ActionResult Remove(int id)
    {
        var todoItem = _todoList.FirstOrDefault(t => t.Id == id);
        if (todoItem != null)
        {
            _todoList.Remove(todoItem);
        }
        return Json(new { success = true });
    }
}
