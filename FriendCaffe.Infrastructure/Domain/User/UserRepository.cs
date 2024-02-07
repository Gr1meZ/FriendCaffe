using FriendCaffe.Application.Exceptions;
using FriendCaffe.Domain.Aggregates.User;
using FriendCaffe.Domain.SeedWork;
using FriendCaffe.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
namespace FriendCaffe.Infrastructure.Domain.User;

public class UserRepository : Repository<FriendCaffe.Domain.Aggregates.User.User>, IUserRepository
{
    public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<FriendCaffe.Domain.Aggregates.User.User> GetByEmailAsync(string email)
    {
        var user = await ApplicationDbContext.Users
            .FirstOrDefaultAsync(x => x.Email.Value == email);
        
        if (user == null)
            throw new NotFoundException<FriendCaffe.Domain.Aggregates.User.User>(user);
        
        return user;
    }


    public bool IsEmailExists(string email) 
        =>  ApplicationDbContext.Users.Any(x => x.Email.Value == email);
  

    public bool IsNicknameExists(string nickname) 
        =>  ApplicationDbContext.Users.Any(x => x.UserDetails.Nickname == nickname);
    
}