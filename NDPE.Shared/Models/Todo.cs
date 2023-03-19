using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NDPE.Shared.Models;

public class Todo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
}

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
    : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}

