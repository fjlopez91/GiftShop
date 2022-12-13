using GiftShop.API;
using GiftShop.API.Middlewares;
using GiftShop.Application;
using GiftShop.Application.Services;
using GiftShop.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddWebApi();
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("AppConnection"));
builder.Services.AddSecurity(builder.Configuration);
builder.Services.AddCoreApplication();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var identityInitializer = services.GetRequiredService<IdentityInitializerService>();
    var configuration = services.GetRequiredService<IConfiguration>();
    await identityInitializer!.Run(configuration["AdminEmail"]);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();