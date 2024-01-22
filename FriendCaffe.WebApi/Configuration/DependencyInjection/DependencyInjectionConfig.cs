using FriendCaffe.Infrastructure.IoC;

namespace FriendCaffe.WebApi.Configuration.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        NativeInjector.RegisterServices(services);
    }
}