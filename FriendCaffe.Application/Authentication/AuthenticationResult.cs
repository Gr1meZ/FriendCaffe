using FriendCaffe.Domain.Entities.User;

namespace FriendCaffe.Application.Authentication;

public record AuthenticationResult
{
    public AuthenticationResult(Guid userId, string email, string token)
    {
        UserId = userId;
        Email = email;
        Token = token;
    }
    
    public Guid UserId { get; }
    public string Email { get;  }
    public string Token { get; }
}
