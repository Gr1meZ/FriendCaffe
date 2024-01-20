using FriendCaffe.Application;
using FriendCaffe.Application.Configuration.AutoMapper;
using FriendCaffe.Infrastructure.Database;
using FriendCaffe.WebApi;
using FriendCaffe.WebApi.Configuration.AutoMapper;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    builder.Services.RegisterDatabase(builder.Configuration);
    builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssemblies([typeof(ApplicationAssembleReference).Assembly, typeof(PresentationAssembleReference).Assembly]));
    builder.Services.AddAutoMapper(typeof(PresentationProfile), typeof(ApplicationProfile));
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();

    app.UseCors(cors =>
    {
        cors.AllowAnyHeader();
        cors.AllowAnyMethod();
        cors.AllowAnyOrigin();
    });

    app.MapControllers();
    
    app.Run();

}
// Configure the HTTP request pipeline.

