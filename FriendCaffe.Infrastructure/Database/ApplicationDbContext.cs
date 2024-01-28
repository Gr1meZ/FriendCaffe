using FriendCaffe.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FriendCaffe.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().OwnsOne(p => p.Address);
        modelBuilder.Entity<User>().OwnsOne(p => p.UserDetails);
        modelBuilder.Entity<User>().OwnsOne(p => p.Email);
        modelBuilder.Entity<User>().OwnsOne(p => p.Password);

    }
    
    public DbSet<User> Users { get; set; }
}