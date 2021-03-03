using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp {
    
     public class Cli {
        // here we are creating a method that takes in a string that allows the user to input something then returns what their input was.
        public static string GetString(string prompt) {
            Console.Write($"{prompt}: ");
            var response = Console.ReadLine();
            return response;

        } // it's taking in a string and calling the GetString method from above and converting it into a datetime type, if there is no input, it will return null.
        public static DateTime? GetDateTime(string Prompt) {
            var response = GetString(Prompt);
            if(response.Length == 0) {
                return null;
            }
            return Convert.ToDateTime(response);
        }
        // here we are taking in a string and printing it.
        public static void DisplayLine(string prompt = null) {
            Console.WriteLine($"{prompt}");
        }

        // here we are receiving a string and then we assign that string to response and converting it back in an int.
        public static int Getint(string prompt) {
            var response = GetString(prompt);
            return Convert.ToInt32(response);
        }


     }
}
