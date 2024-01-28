using FriendCaffe.Infrastructure.IoC;
using FriendCaffe.WebApi.Configuration.AutoMapper;
using FriendCaffe.WebApi.Configuration.Database;
using FriendCaffe.WebApi.Configuration.DependencyInjection;
using FriendCaffe.WebApi.Configuration.MediatR;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Configuration
        .SetBasePath(builder.Environment.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
        .AddEnvironmentVariables();
    
    builder.Services.AddControllers();
    
    builder.Services.AddEndpointsApiExplorer();
    
    builder.Services.AddSwaggerGen();
    
    builder.Services.AddDatabase(builder.Configuration);
    
    builder.Services.RegisterMediatR();
    builder.Services.AddJwtAuth(builder.Configuration);

    builder.Services.AddAutoMapperConfiguration();
    
    builder.Services.AddDependencyInjectionConfiguration();

}


var app = builder.Build();
{
    await app.Services.AutoMigrateDatabaseAsync();
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();
    
    app.UseRouting();

    app.UseCors(cors =>
    {
        cors.AllowAnyHeader();
        cors.AllowAnyMethod();
        cors.AllowAnyOrigin();
    });
    
    app.UseAuthentication();
    app.UseAuthorization();
    
    app.MapControllers();
    
    app.Run();

}
// Configure the HTTP request pipeline.

