using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<bool> IsEmailExistsAsync(string email);
    Task<bool> IsNicknameExistsAsync(string nickname);
}