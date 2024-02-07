using DevOne.Security.Cryptography.BCrypt;
using FriendCaffe.Domain.Aggregates.User;
using FriendCaffe.Domain.Aggregates.User.Address;
using FriendCaffe.Domain.Aggregates.User.Email;
using FriendCaffe.Domain.Aggregates.User.Password;
using FriendCaffe.Domain.Aggregates.User.UserDetails;
using FriendCaffe.Domain.SeedWork;
using FriendCaffe.UnitTests.Builders;
using Moq;

namespace FriendCaffe.UnitTests.Domain;

//TODO Split value objects to other test classes
public class UserTests
{
    private readonly Mock<IUserRepository> _mock = new();

    [Fact]
    public void Address_Must_ThrowExceptionWhenNotValid()
    {
        //Act & Assert
        Assert.Throws<DomainException>(() =>
        {
            Address.Create("", "", "");
        });
    }

    [Fact]
    public void Address_Must_BeCreated()
    {
        //Arrange
        const string country = "Belarus";
        const string city = "Minsk";
        const string street = "Pobeda Street 167";

        //Act
        var address = Address.Create(street, country, city);

        //Assert
        Assert.Equal(country, address.Country);
        Assert.Equal(city, address.City);
        Assert.Equal(street, address.Street);
    }

    [Fact]
    public void Email_Must_BeValid()
    {
        //Arrange
        const string emailFromRequest = "test@mail.ru";
        _mock.Setup(x => x.IsEmailExists(emailFromRequest))
            .Returns(false);

        //Act
        var email =  Email.Create(emailFromRequest, _mock.Object);

        //Assert
        Assert.Equal(emailFromRequest, email.Value);
    }

    //TODO move email existing check to user 
    [Fact]
    public void Email_IsExisting_ThrowsException()
    {
        //Arrange
        const string emailFromRequest = "test@mail.ru";
        _mock.Setup(x => x.IsEmailExists(emailFromRequest))
            .Returns(true);

        //Act & Assert
        Assert.Throws<DomainException>(() => Email.Create(emailFromRequest, _mock.Object));
    }

    [Fact]
    public void Email_IsNotValid_ThrowsException()
    {
        //Arrange
        const string emailFromRequest = "some come";
        _mock.Setup(x => x.IsEmailExists(emailFromRequest))
            .Returns(false);

        //Act & Assert
        Assert.Throws<DomainException>(() => Email.Create(emailFromRequest, _mock.Object));
    }
    
    [Theory]
    [InlineData("456Lol321&*")]
    [InlineData("Admin1**")]
    [InlineData("User5***")]

    public void Password_MustBe_Valid(string passwordValue)
    {
       
        //Act
        var password = Password.Create(passwordValue);
        
        //Assert
        Assert.True(BCryptHelper.CheckPassword(passwordValue, password.Hash));
    }
    
    [Fact]
    public void Password_IsNot_Valid_ThrowsException()
    {
        //Arrange
        const string expectedPassword = "4&*";
        
        //Act & Assert
        Assert.Throws<DomainException>(() => Password.Create(expectedPassword));
    }
    
    [Fact]
    public void UsersDetails_MustBe_Valid()
    {
        //Arrange
        const string name = "Artyom";
        const string surname = "Ivanov";
        const string nickname = "Hacker98";
        _mock.Setup(x => x.IsNicknameExists(nickname))
            .Returns(false);
        
        //Act
        var userDetails =  UserDetails.Create(name, surname, nickname, _mock.Object);
        
        //Assert
        Assert.Equal(name, userDetails.Name);
        Assert.Equal(surname, userDetails.Surname);
        Assert.Equal(nickname, userDetails.Nickname);
    }
    
    [Fact]
    public void UsersDetails_ThrowsException_WhenNullOrEmpty()
    {
        //Arrange
        _mock.Setup(x => x.IsNicknameExists(It.IsAny<string>()))
            .Returns(false);
        
        //Act && Assert
        Assert.Throws<DomainException>(() =>  UserDetails.Create("", "", "", _mock.Object));
    }
    
    [Fact]
    public void Nickname_IsNotValid_ThrowsException()
    {
        //Arrange
        _mock.Setup(x => x.IsNicknameExists(It.IsAny<string>()))
            .Returns(false);
        
        //Act && Assert
        Assert.Throws<DomainException>(() =>  UserDetails.Create("Artyom", "Ivanov", "A#$8", _mock.Object));
    }
    
    //TODO move nickname checking to user
    [Fact]
    public void Nickname_AlreadyExists_ThrowsException()
    {
        //Arrange
        _mock.Setup(x => x.IsNicknameExists(It.IsAny<string>()))
            .Returns(true);
        
        //Act && Assert
        Assert.Throws<DomainException>(() =>  UserDetails.Create("Artyom", "Ivanov", "Gr1meZ", _mock.Object));
    }
    
    [Fact]
    public void User_About_MustBe_Valid()
    {
        //Arrange
        var about = "Hey, my name is Artyom and this is my about text";
        var user =  UserBuilder.CreateSpecificUser(_mock.Object);
        
        //Act
        user.UserDetails.CreateAbout(about);
        
        //Assert
        Assert.Equal(about, user.UserDetails.About);
    }
    
    [Fact]
    public void User_About_IsNotValid_ThrowsException()
    {
        //Arrange
        var about = string.Empty;
        var user =  UserBuilder.CreateSpecificUser(_mock.Object);
        
        //Act & Assert
        Assert.Throws<DomainException>(() => user.UserDetails.CreateAbout(about));
    }
    
    [Fact]
    public void UserDetails_Change_IsValid()
    {
        //Arrange
        var user = UserBuilder.CreateSpecificUser(_mock.Object);
        var name = "Ivan";
        var surname = "Ivanov";
        var nickname = "Godzila13";
        _mock.Setup(x => x.IsNicknameExists(nickname)).Returns(false);

        //Act
        user.UserDetails.Change(name, surname, nickname, _mock.Object);
        
        //Assert
        Assert.Equal(name, user.UserDetails.Name);
        Assert.Equal(surname, user.UserDetails.Surname);
        Assert.Equal(nickname, user.UserDetails.Nickname);
    }
    
}