using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    bool IsEmailExists(string email);
    bool IsNicknameExists(string nickname);
}