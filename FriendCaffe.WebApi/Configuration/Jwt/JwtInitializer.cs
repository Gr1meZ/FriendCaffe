using FriendCaffe.WebApi.Services.Jwt;

namespace FriendCaffe.WebApi.Configuration.Jwt;

public static class JwtInitializer
{
    public static void AddJwtService(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<JwtService>();
    }
}