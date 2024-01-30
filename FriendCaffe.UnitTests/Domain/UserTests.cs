using DevOne.Security.Cryptography.BCrypt;
using FriendCaffe.Domain.Entities.User;
using FriendCaffe.Domain.Entities.User.Objects.Address;
using FriendCaffe.Domain.Entities.User.Objects.Email;
using FriendCaffe.Domain.Entities.User.Objects.Password;
using FriendCaffe.Domain.Entities.User.Objects.UserDetails;
using FriendCaffe.Domain.SeedWork;
using FriendCaffe.UnitTests.Builders;
using Moq;

namespace FriendCaffe.UnitTests.Domain;

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
    public async Task Email_Must_BeValid()
    {
        //Arrange
        const string emailFromRequest = "test@mail.ru";
        _mock.Setup(x => x.IsEmailExistsAsync(emailFromRequest))
            .ReturnsAsync(false);

        //Act
        var email = await Email.CreateAsync(emailFromRequest, _mock.Object);

        //Assert
        Assert.Equal(emailFromRequest, email.Value);
    }

    [Fact]
    public async Task Email_IsExisting_ThrowsException()
    {
        //Arrange
        const string emailFromRequest = "test@mail.ru";
        _mock.Setup(x => x.IsEmailExistsAsync(emailFromRequest))
            .ReturnsAsync(true);

        //Act & Assert
        await Assert.ThrowsAsync<EntityValidationException>(() => Email.CreateAsync(emailFromRequest, _mock.Object));
    }

    [Fact]
    public async Task Email_IsNotValid_ThrowsException()
    {
        //Arrange
        const string emailFromRequest = "some come";
        _mock.Setup(x => x.IsEmailExistsAsync(emailFromRequest))
            .ReturnsAsync(false);

        //Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => Email.CreateAsync(emailFromRequest, _mock.Object));
    }
    
    [Fact]
    public void Password_MustBe_Valid()
    {
        //Arrange
        const string expectedPassword = "456Lol321&*";
       
        //Act
        var password = Password.Create(expectedPassword);
        
        //Assert
        Assert.True(BCryptHelper.CheckPassword(expectedPassword, password.Hash));
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
    public async Task UsersDetails_MustBe_Valid()
    {
        //Arrange
        const string name = "Artyom";
        const string surname = "Ivanov";
        const string nickname = "Hacker98";
        _mock.Setup(x => x.IsNicknameExistsAsync(nickname))
            .ReturnsAsync(false);
        
        //Act
        var userDetails = await UserDetails.CreateAsync(name, surname, nickname, _mock.Object);
        
        //Assert
        Assert.Equal(name, userDetails.Name);
        Assert.Equal(surname, userDetails.Surname);
        Assert.Equal(nickname, userDetails.Nickname);
    }
    
    [Fact]
    public async Task UsersDetails_ThrowsException_WhenNullOrEmpty()
    {
        //Arrange
        _mock.Setup(x => x.IsNicknameExistsAsync(It.IsAny<string>()))
            .ReturnsAsync(false);
        
        //Act && Assert
        await Assert.ThrowsAsync<DomainException>(() =>  UserDetails.CreateAsync("", "", "", _mock.Object));
    }
    
    [Fact]
    public async Task Nickname_IsNotValid_ThrowsException()
    {
        //Arrange
        _mock.Setup(x => x.IsNicknameExistsAsync(It.IsAny<string>()))
            .ReturnsAsync(false);
        
        //Act && Assert
        await Assert.ThrowsAsync<DomainException>(() =>  UserDetails.CreateAsync("Artyom", "Ivanov", "A#$8", _mock.Object));
    }
    
    [Fact]
    public async Task Nickname_AlreadyExists_ThrowsException()
    {
        //Arrange
        _mock.Setup(x => x.IsNicknameExistsAsync(It.IsAny<string>()))
            .ReturnsAsync(true);
        
        //Act && Assert
        await Assert.ThrowsAsync<EntityValidationException>(() =>  UserDetails.CreateAsync("Artyom", "Ivanov", "Gr1meZ", _mock.Object));
    }
    
    [Fact]
    public async Task User_About_MustBe_Valid()
    {
        //Arrange
        var about = "Hey, my name is Artyom and this is my about text";
        var user = await  UserBuilder.CreateSpecificUser(_mock.Object);
        
        //Act
        user.UserDetails.CreateAbout(about);
        
        //Assert
        Assert.Equal(about, user.UserDetails.About);
    }
    
    [Fact]
    public async Task User_About_IsNotValid_ThrowsException()
    {
        //Arrange
        var about = string.Empty;
        var user = await  UserBuilder.CreateSpecificUser(_mock.Object);
        
        //Act & Assert
        Assert.Throws<DomainException>(() => user.UserDetails.CreateAbout(about));
    }
    
    [Fact]
    public async Task UserDetails_Change_IsValid()
    {
        //Arrange
        var user = await  UserBuilder.CreateSpecificUser(_mock.Object);
        var name = "Ivan";
        var surname = "Ivanov";
        var nickname = "Godzila13";
        _mock.Setup(x => x.IsNicknameExistsAsync(nickname)).ReturnsAsync(false);

        //Act
        await user.UserDetails.Change(name, surname, nickname, _mock.Object);
        
        //Assert
        Assert.Equal(name, user.UserDetails.Name);
        Assert.Equal(surname, user.UserDetails.Surname);
        Assert.Equal(nickname, user.UserDetails.Nickname);
    }
    
}