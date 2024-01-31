using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adress_Book.Services
{
    public class Menu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. List All Adresses");
            Console.WriteLine("2. Find Person");
            Console.WriteLine("3. Add Person");
            Console.WriteLine("4. Remove Person");
        }

        // Inputen för menyn, felmedelande om annat än 1-4 anges.
        public int GetUserChoice()
        {
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return GetUserChoice();
            }
        }
    }
}
