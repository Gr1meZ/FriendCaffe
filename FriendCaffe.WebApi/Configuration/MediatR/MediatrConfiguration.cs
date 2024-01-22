using FriendCaffe.Application;

namespace FriendCaffe.WebApi.Configuration.MediatR;

public static class MediatrConfiguration
{
    public static void RegisterMediatR(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies([typeof(ApplicationAssembleReference).Assembly, typeof(PresentationAssembleReference).Assembly]));
    }
}