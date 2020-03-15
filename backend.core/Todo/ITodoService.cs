using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.Data.Models;

namespace Backend.Core.Todo
{
    public interface ITodoService
    {
        bool AddTodo(TodoItem item);
        Task<List<TodoItem>> GetAllTodoItem();
        TodoItem GetTodoItem(long id);
        bool UpdateTodoItem(TodoItem NewItem, long IdOldItem);
        bool DeleteTodoItem(long id);

    }
}
