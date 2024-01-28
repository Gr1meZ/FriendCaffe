using FriendCaffe.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FriendCaffe.WebApi.Configuration.Database;

public static class AutoMigration
{
    public static async Task AutoMigrateDatabaseAsync (this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}