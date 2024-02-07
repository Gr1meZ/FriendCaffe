using FriendCaffe.Domain.Aggregates.User;
using FriendCaffe.Domain.Aggregates.User.Email;
using FriendCaffe.Domain.Aggregates.User.Password;
using FriendCaffe.Domain.Aggregates.User.UserDetails;

namespace FriendCaffe.UnitTests.Builders;

public class UserBuilder
{
    public static User CreateSpecificUser(IUserRepository userRepository)
    {
        var email =  Email.Create("test@mail.ru", userRepository);
        var password = Password.Create("567Lol123&*");
        var userDetails =  UserDetails.Create("Artyom", "Korzun", "Gr1meZ", userRepository);
        
        return User.Create(email, password, userDetails);
    }
}