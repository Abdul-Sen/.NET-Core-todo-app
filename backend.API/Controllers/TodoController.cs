using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Core.Todo;
using Backend.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private ITodoService _TodoService;
        public TodoController(ITodoService todoService)
        {
            _TodoService = todoService;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetItems()
        {
            List<TodoItem> res = await _TodoService.GetAllTodoItem();
            return Ok(res);
        }

        // POST: api/Todo
        [HttpPost]
        public ActionResult<bool> Post(TodoItem item)
        {
            bool result = _TodoService.AddTodo(item);
            return result;
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "Get")]
        public TodoItem Get(long id)
        {
            TodoItem item = _TodoService.GetTodoItem(id);
            return item;
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, TodoItem value)
        {
            bool result = _TodoService.UpdateTodoItem(value, id);
            Console.WriteLine("result is..  " + result.ToString());
            if(result == true)
            {
                return Ok();
            }
            return StatusCode(500, "error updating todo item");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            bool res = _TodoService.DeleteTodoItem(id);
            return Ok(res);
        }
    }
}
