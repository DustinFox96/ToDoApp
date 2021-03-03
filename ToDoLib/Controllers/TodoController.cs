using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoLib.Models;

namespace ToDoLib.Controllers {
    public class TodoController {
        private readonly ToDoDbContext _context;

        public async Task<IEnumerable <Todo>>  GetAll() {
            return await _context.Todos
                                .Include(x => x.Category) // this includes the Category when you call the GetAll, it sorta like an easy join, you don't need to do this on the Category controller becasue it's does not join anything.
                                .ToListAsync();
        }

        public async Task<Todo> Create(Todo todo) {
            _context.Todos.Add(todo);
            var rowsAffect = await _context.SaveChangesAsync();
            if(rowsAffect != 1) {
                throw new Exception("Create failed");
            }
            return todo;
        }


        public TodoController() {
            _context = new ToDoDbContext();
        }
    }
}
