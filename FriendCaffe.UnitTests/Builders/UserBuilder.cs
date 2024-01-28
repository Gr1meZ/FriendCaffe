using FriendCaffe.Domain.Entities.User;
using FriendCaffe.Domain.Entities.User.Objects.Address;
using FriendCaffe.Domain.Entities.User.Objects.Email;
using FriendCaffe.Domain.Entities.User.Objects.Password;
using FriendCaffe.Domain.Entities.User.Objects.UserDetails;

namespace FriendCaffe.UnitTests.Builders;

public class UserBuilder
{
    public static async Task<User> CreateSpecificUser(IUserRepository userRepository)
    {
        var email = await Email.CreateAsync("test@mail.ru", userRepository);
        var password = Password.Create("567Lol123&*");
        var userDetails = await UserDetails.CreateAsync("Artyom", "Korzun", "Gr1meZ", userRepository);
        
        return User.Create(email, password, userDetails);
    }
}