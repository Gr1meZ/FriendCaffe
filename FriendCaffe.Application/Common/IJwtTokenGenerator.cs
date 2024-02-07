using FriendCaffe.Domain.Aggregates.User;

namespace FriendCaffe.Application.Common;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}