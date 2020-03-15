using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Models
{
    public class TodoItemContext: DbContext
    {
        public TodoItemContext(DbContextOptions<TodoItemContext> options) : base(options) { }
        public DbSet<TodoItem> MyItems { get; set; }
    }
}
