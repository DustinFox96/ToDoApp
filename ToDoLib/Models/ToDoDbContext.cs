using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

// this class is used to connect to the database
namespace ToDoLib.Models {
    public class ToDoDbContext : DbContext {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Todo> Todos { get; set; }

        public ToDoDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if(!builder .IsConfigured) {
                var connStr = "server=localhost\\sqlexpress;" +
                              "database=ToDoDb;" +
                              "trusted_connection=true;";
                builder.UseSqlServer(connStr);

            }
        }
        // this is a method that is used sometimes when you need a value to be unique that is not a Pk
        protected override void OnModelCreating(ModelBuilder builder) {

        }

        

    }
}
