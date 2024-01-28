using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<bool> IsEmailExists(string email);
    Task<bool> IsNicknameExistsAsync(string nickname);
}