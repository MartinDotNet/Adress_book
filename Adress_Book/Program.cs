namespace Adress_Book;

using Adress_Book.Models;
using Adress_Book.Services;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        AdressService service = new AdressService();
        service.LoadAdresses();

        while (true)
        {
            Console.Clear();
            menu.DisplayMenu();
            int choice = menu.GetUserChoice();

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    service.DisplayAddressList();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Find Person");
                    var emailSearch = service.GetInput("Enter Email: ");
                    service.FindPerson(emailSearch!);
                    break;
                case 3:
                    Console.Clear();
                    service.GetUserInputForPerson();
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Remove Person");
                    var email = service.GetInput("Enter Email: ");
                    service.RemovePerson(email!);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();





        }

    }
}
