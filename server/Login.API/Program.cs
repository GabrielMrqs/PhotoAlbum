using Albums.Domain;
using Albums.Infra.LoginModule;
using Login.Application;
using Login.Application.DTO.UserModule;
using Login.Application.DTO.LoginModule;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Infra;

var builder = WebApplication.CreateBuilder(args);

LoadEnvironmentVariables();

AddServices(builder);

builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

app.UseHttpsRedirection();

app.MapPost("/verifyUser", async (IMediator mediator, UserDTO user) =>
{
    var response = await mediator.Send(new VerifyUserRequest(user));
})
.WithName("Send Verification");

app.MapPost("/addUser", async (IMediator mediator, UserDTO user) =>
{
    var response = await mediator.Send(new AddUserRequest(user));
})
.WithName("Add User");

app.MapPost("/login", async (IMediator mediator, LoginDTO login) =>
{
    return await mediator.Send(new LoginRequest(login));
})
.WithName("Login");

await ApplyMigrations();

app.Run();

void LoadEnvironmentVariables()
{
    var root = Directory.GetCurrentDirectory();
    var dotenv = Path.Combine(root, ".env");
    DotEnv.Load(dotenv);
}

async Task ApplyMigrations()
{
    using var scope = app.Services.CreateAsyncScope();
    await scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.MigrateAsync();
}

void AddServices(WebApplicationBuilder builder)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddMediatR(typeof(VerifyUserHandler));
    builder.Services.AddCors(opt => opt.AddPolicy("cors", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
    builder.Services.AddScoped<BaseRepository<User>>();
    builder.Services.AddScoped<LoginRepository>();
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}