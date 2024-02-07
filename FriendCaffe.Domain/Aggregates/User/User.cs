using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User;

public class User : Entity
{
    private User(Email.Email email, Password.Password password, UserDetails.UserDetails userDetails)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
        UserDetails = userDetails;
    }

    protected User()
    {
    }

    public static User Create(Email.Email email, Password.Password password, UserDetails.UserDetails userDetails)
    {
        return new User(email, password, userDetails);
    }
    
    public Email.Email Email { get; private set; }
    public Password.Password Password { get; private set; }
    public Address.Address? Address { get; private set; }
    public UserDetails.UserDetails UserDetails { get; private set; }

    private IReadOnlyList<Post.Post> _posts = new List<Post.Post>();
}