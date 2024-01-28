using FriendCaffe.Domain.Entities.User;
using FriendCaffe.Domain.SeedWork;
using FriendCaffe.Infrastructure.Database;

namespace FriendCaffe.Infrastructure.Domain.User;

public class UserRepository : Repository<FriendCaffe.Domain.Entities.User.User>, IUserRepository
{
    public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public Task<FriendCaffe.Domain.Entities.User.User> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsEmailExists(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsNicknameExistsAsync(string nickname)
    {
        throw new NotImplementedException();
    }
}