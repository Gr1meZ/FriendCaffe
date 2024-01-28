namespace FriendCaffe.Application.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(Domain.Entities.User.User user);
}