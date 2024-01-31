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
    // Här initierar jag min sökväg till filen, måste bytas för ny användare.
    private readonly FileManager _fileManager = new FileManager(@"C:\DotNetSchool\CSharp\Adress_Book\adresses.json");
    private List<Person> _adressList = new List<Person>();

    // Här laddar jag upp filen, om den inte är tom kommer den deserialize och läggas i listan. 
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

    // Input för att skapa en ny användare
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
    // En input metod som underlättar då jag har inputs på många ställen, Den går bara vidare om något anges i inputen. Trimmar även bort whitespace om det finns.
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

    // Lägger till användare i listan och sparar listan i filen. Kollar först så att användarens email inte redan är registrerad
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

    // Letar i listan efter användaren. gjorde en toLower på både inputen och sökresultatet så de kan söka med stora eller små bokstäver och ändå matcha.
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

    // Liknande findperson fast tar bort resultatet istället för att visa det.
    public void RemovePerson(string email) 
    {
        try
        {
            _adressList.RemoveAll(person => person.Email.ToLowerInvariant() == email.ToLowerInvariant());
            _fileManager.SaveJson(JsonConvert.SerializeObject(_adressList));
        }

        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    // loopar igenom listan och visar alla adresserna.
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


