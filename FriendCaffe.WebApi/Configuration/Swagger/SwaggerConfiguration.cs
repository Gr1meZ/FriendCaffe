using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace FriendCaffe.WebApi.Configuration.Swagger
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Friend Caffe API",
                    Description = "Friend Caffe Social Network API"
                });

                s.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                
                s.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}