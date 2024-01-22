using FriendCaffe.Application.Configuration.AutoMapper;

namespace FriendCaffe.WebApi.Configuration.AutoMapper;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddAutoMapper(typeof(PresentationProfile), typeof(ApplicationProfile));
    }
}