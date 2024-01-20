using Microsoft.EntityFrameworkCore;

namespace FriendCaffe.Infrastructure.Database;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}