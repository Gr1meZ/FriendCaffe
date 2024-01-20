
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User;

public class User : Entity
{
    public string FirstName { get; private set; } 
    public string LastName { get; private set; }
    public string IdentityId { get; private set; }
    public string UserName { get; private set; } 
    public string Email { get; private set; }
    
    public string PasswordHash { get; private set; }

    private readonly List<RefreshToken> _refreshTokens = new();
    public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

    protected User() { }

    private User(Guid id, string firstName, string lastName, string identityId, string email, string userName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        IdentityId = identityId;
        Email = email;
        UserName = userName;
    }

    public static User CreateByEmail(Guid id, string firstName, string lastName, string identityId, string email,
        string userName)
    {
        return new User()
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            IdentityId = identityId,
            Email = email,
            UserName = userName,
        };
    }
    
    public bool HasValidRefreshToken(string refreshToken)
    {
        return _refreshTokens.Any(rt => rt.Token == refreshToken && rt.Active);
    }

    public void AddRefreshToken(string token, Guid userId, string remoteIpAddress, double daysToExpire = 5)
    {
        _refreshTokens.Add(new RefreshToken(token, DateTime.UtcNow.AddDays(daysToExpire), userId, remoteIpAddress));
    }

    public void RemoveRefreshToken(string refreshToken)
    {
        _refreshTokens.Remove(_refreshTokens.First(t => t.Token == refreshToken));
    }
}