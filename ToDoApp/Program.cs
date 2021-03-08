using System;
using System.Threading.Tasks;
using ToDoLib;
using ToDoLib.Controllers;

namespace ToDoApp {
    class Program {
        // here we are instantiateing a new TodoController and CategoryController objects, meaning we are creating it.
        TodoController ToDoCtrl = new TodoController();
        CategoryController CatCtrl = new CategoryController();




       async Task ListAllTodos() {
            Cli.DisplayLine("called ListAllTodos()");
            Cli.DisplayLine();
            var todos = await ToDoCtrl.GetAll();
            foreach(var todo in todos) {
                Console.WriteLine($"{todo}");
            }
            Cli.DisplayLine();
        }


        


        async Task CreateTodo() {
            Cli.DisplayLine("called CreateTodos()");
            Cli.DisplayLine();
            var category = await CatCtrl.GetAll(); // this is creating an instance of catergory for belows use
            var todo = new Todo(); // this is creating a instance of ToDo.

            todo.Id = 0;
            todo.Description = Cli.GetString("Enter Description");
            todo.Due = Cli.GetDateTime("Enter Due Date");
            todo.Note = Cli.GetString("Enter note");
            Cli.DisplayLine("Categories");
            foreach(var c in category) {
                Cli.DisplayLine($" {c.Id} : {c.Name}");
            }
            todo.CategoryId = Cli.Getint("Select category");
            var newTodo = await ToDoCtrl.Create(todo);
            Cli.DisplayLine();
            Cli.DisplayLine();
            //todo.CategoryId = Cli.Getint("1 : Personal \n 2 : Professional");


            await ToDoCtrl.Create(todo); // this line is adding the ToDo object to the database


            
           

        }

        async Task Run() {
            Cli.DisplayLine("Todo App");
            var option = DisplayMenu();
            while(option != 0) {
                switch(option) {
                    case 1:
                         await ListAllTodos();
                            break;
                    case 2:
                        await CreateTodo();
                            break;
                     
                    case 0:
                        return;
                    default:
                        Cli.DisplayLine("Invailed menu Option");
                        break;
                }
                option = DisplayMenu();
            }

        }
        int DisplayMenu() {
            Cli.DisplayLine("Menu");
            Cli.DisplayLine("1 : List all todos");
            Cli.DisplayLine("2 : Add ToDo");
            Cli.DisplayLine("0 : Exit");
            var option = Cli.Getint("Enter your menu number");
            return option;
        }





        static async Task Main(string[] args) {

            var pgm = new Program();
           await pgm.Run();

            //var aStr = Cli.GetString("Enter a string");
            //var anInt = Cli.Getint("Enter a int");
            //var aDate = Cli.GetDateTime("Enter a vaild date");// mm/dd/yyyy
            //var aDate2 = Cli.GetDateTime("Just press enter");
            //Console.WriteLine($"{anInt}");
            //Console.WriteLine($"{anInt}");
            //Console.WriteLine($"{aDate} [{aDate2}]");

        }
    }
}
