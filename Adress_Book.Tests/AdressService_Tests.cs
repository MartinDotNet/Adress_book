
using Adress_Book.Models;
using Adress_Book.Services;

namespace Adress_Book.Tests;

public class AdressService_Tests
{
    [Fact]
    public void AddPerson_Should_Add_A_User_To_List_Then_Return_True()
    {
        // Arrange
        AdressService adressService = new AdressService();
        Person person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            PhoneNumber = "1234567890",
            Adress = "Huvudgatan 32"
        };

        // Act
        bool result = adressService.AddPerson(person);

        // Assert
        Assert.True(result);
        Assert.NotNull(person);


    }

}
