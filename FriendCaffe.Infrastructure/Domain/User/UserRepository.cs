using FriendCaffe.Application.Exceptions;
using FriendCaffe.Domain.Entities.User;
using FriendCaffe.Domain.SeedWork;
using FriendCaffe.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FriendCaffe.Infrastructure.Domain.User;

public class UserRepository : Repository<FriendCaffe.Domain.Entities.User.User>, IUserRepository
{
    public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<FriendCaffe.Domain.Entities.User.User> GetByEmailAsync(string email)
    {
        var user = await ApplicationDbContext.Users
            .FirstOrDefaultAsync(x => x.Email.Value == email);
        
        if (user == null)
            throw new NotFoundException($"User with email '{email}' not found");
        
        return user;
    }

    public async Task<bool> IsEmailExists(string email) 
        => await ApplicationDbContext.Users.AnyAsync(x => x.Email.Value == email);
  

    public async Task<bool> IsNicknameExistsAsync(string nickname) 
        => await ApplicationDbContext.Users.AnyAsync(x => x.UserDetails.Nickname == nickname);
    
}