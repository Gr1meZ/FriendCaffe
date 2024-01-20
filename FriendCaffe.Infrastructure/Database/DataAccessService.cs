using FriendCaffe.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FriendCaffe.Infrastructure.Database;

public static class DataAccessService
{
    public static  IServiceCollection RegisterDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
                               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString, b => 
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .EnableSensitiveDataLogging();
            
        });
        
        services.AddDbContext<UserDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString, b => 
                    b.MigrationsAssembly(typeof(UserDbContext).Assembly.FullName))
                .EnableSensitiveDataLogging();
            
        });
        
        return services;
    }
}