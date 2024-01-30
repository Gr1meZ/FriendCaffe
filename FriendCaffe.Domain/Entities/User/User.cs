using FriendCaffe.Domain.Entities.User.Objects.Address;
using FriendCaffe.Domain.Entities.User.Objects.Email;
using FriendCaffe.Domain.Entities.User.Objects.Password;
using FriendCaffe.Domain.Entities.User.Objects.UserDetails;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User;

public class User : Entity
{
    private User(Email email, Password password, UserDetails userDetails)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
        UserDetails = userDetails;
    }

    protected User()
    {
    }

    public static User Create(Email email, Password password, UserDetails userDetails)
    {
        return new User(email, password, userDetails);
    }
    
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Address? Address { get; private set; }
    public UserDetails UserDetails { get; private set; }

    private IReadOnlyList<Post.Post> _posts = new List<Post.Post>();
}