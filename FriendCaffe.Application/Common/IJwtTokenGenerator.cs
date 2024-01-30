namespace FriendCaffe.Application.Common;

public interface IJwtTokenGenerator
{
    string GenerateToken(Domain.Entities.User.User user);
}