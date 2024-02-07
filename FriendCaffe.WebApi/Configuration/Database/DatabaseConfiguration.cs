using FriendCaffe.Application.Configuration.Data;
using FriendCaffe.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FriendCaffe.WebApi.Configuration.Database;

public static class DatabaseConfiguration
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
                               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString, b => 
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .EnableSensitiveDataLogging();
        });
        
        services.AddScoped<ISqlConnectionFactory>(x => new SqlConnectionFactory(connectionString));
    }
}