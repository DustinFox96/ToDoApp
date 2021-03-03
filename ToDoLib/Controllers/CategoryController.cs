using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoLib.Models;

namespace ToDoLib.Controllers {
    public class CategoryController {
        private readonly ToDoDbContext _context;

        public async Task<IEnumerable <Category>> GetAll() {
            return await _context.Categories.ToListAsync();
        } 

        public async Task<Category> Create(Category category) {
            _context.Categories.Add(category);
            var rowsAffect = await _context.SaveChangesAsync();
            if(rowsAffect != 1) {
                throw new Exception("Create failed");
            }
            if(category == null) {
                throw new Exception("Category cannot be null");
            }
            if(category.Id != 0) {
                throw new Exception("Input must have Id set to zero");
            }
            return category;
        }




        public CategoryController() {
        _context = new ToDoDbContext();
        }
    }


}
