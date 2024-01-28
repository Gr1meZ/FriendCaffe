using FriendCaffe.Application.Common;
using FriendCaffe.Application.Configuration.Data;
using FriendCaffe.Domain.Entities.User;
using FriendCaffe.Domain.SeedWork;
using FriendCaffe.Infrastructure.Database;
using FriendCaffe.Infrastructure.Domain.User;
using FriendCaffe.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FriendCaffe.Infrastructure.IoC;

public class NativeInjector
{
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        }
    }
