using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Backend.Core.Todo
{
    public class TodoService : ITodoService
    {
        private TodoItemContext _todoContext;
        public TodoService(TodoItemContext TodoItemContext)
        {
            _todoContext = TodoItemContext;
        }

        public bool AddTodo(TodoItem item)
        {
            try
            {
                _todoContext.TodoItems.Add(item);
                _todoContext.SaveChanges();
                return true;
            }
            catch(Exception ex) when (ex is DbUpdateException || ex is DbUpdateConcurrencyException)
            {
                Console.WriteLine(ex);
                return false;
            }
            catch(Exception allEx)
            {
                Console.WriteLine(allEx);
                return false;
            }
        }

        public bool DeleteTodoItem(long id)
        {
            try
            {
               TodoItem foundItem = _todoContext.TodoItems.Find(id);
                _todoContext.TodoItems.Remove(foundItem);
                _todoContext.SaveChanges();
                return true;
            }
            catch (Exception ex) when (ex is DbUpdateException || ex is DbUpdateConcurrencyException)
            {
                Console.WriteLine(ex);
                return false;
            }
            catch (Exception allEx)
            {
                Console.WriteLine(allEx);
                return false;
            }
        }

        public async Task<List<TodoItem>> GetAllTodoItem()
        {
            return await _todoContext.TodoItems.ToListAsync();
        }

        public TodoItem GetTodoItem(long id)
        {
           TodoItem item = _todoContext.TodoItems.Find(id);
            return item;
        }

        public bool UpdateTodoItem(TodoItem NewItem, long IdOldItem)
        {
            TodoItem FoundItem = _todoContext.TodoItems.Find(IdOldItem);
            FoundItem.IsComplete = NewItem.IsComplete;
            FoundItem.Name = NewItem.Name;
            _todoContext.SaveChanges();
            return true;
        }
    }
}
