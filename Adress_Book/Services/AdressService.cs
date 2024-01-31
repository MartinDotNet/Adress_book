using Adress_Book.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adress_Book.Services;

public class AdressService
{
    private readonly FileManager _fileManager = new FileManager(@"C:\DotNetSchool\CSharp\Adress_Book\adresses.json");
    private List<Person> _adressList = new List<Person>();

    public void LoadAdresses()
    {
        try
        {
            var content = _fileManager.LoadJson();
            if (!string.IsNullOrEmpty(content))
            {
                _adressList = JsonConvert.DeserializeObject<List<Person>>(content)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public void GetUserInputForPerson()
    {
        Person person = new Person();

        person.FirstName = GetInput("Enter First Name: ");
        person.LastName = GetInput("Enter Last Name: ");
        person.PhoneNumber = GetInput("Enter Phone Number: ");
        person.Email = GetInput("Enter Email: ");
        person.Adress = GetInput("Enter Address: ");

        AddPerson(person);
    }

    public string GetInput(string prompt)
    {
        string input;
        do
        {   
            Console.Clear();
            Console.WriteLine(prompt);
            input = Console.ReadLine()?.Trim()!;
        } while (string.IsNullOrEmpty(input));

        return input;
    }

    public bool AddPerson(Person person)
    {
        try
        {
            if (!_adressList.Any(x => x.Email == person.Email))
            {
                _adressList.Add(person);

                _fileManager.SaveJson(JsonConvert.SerializeObject(_adressList));
                return true;
            }
            else
            {
                Console.WriteLine("User Exists");
                return false;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;

    }

    public void FindPerson(string email)
    {
        try
        {
            foreach (Person person in _adressList)
            {
                if (person.Email.ToLowerInvariant() == email.ToLowerInvariant())
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                    Console.WriteLine($"Email: {person.Email}");
                    Console.WriteLine($"Phone Number: {person.PhoneNumber}");
                    Console.WriteLine($"Address: {person.Adress}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
        }

        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public void RemovePerson(string email) 
    {
        try
        {
            _adressList.RemoveAll(person => person.Email.ToLowerInvariant() == email.ToLowerInvariant());
            _fileManager.SaveJson(JsonConvert.SerializeObject(_adressList));
        }

        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public void DisplayAddressList()
    {
        Console.WriteLine("Address List:");
        Console.WriteLine("=============================================");
        foreach (var person in _adressList)
        {
            Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
            Console.WriteLine($"Email: {person.Email}");
            Console.WriteLine($"Phone Number: {person.PhoneNumber}");
            Console.WriteLine($"Address: {person.Adress}");
            Console.WriteLine("---------------------------------------------");
        }
    }




}


