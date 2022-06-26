using Albums.Infra.LoginModule;
using Albums.Infra.UserModule;
using Logins.Application;
using Logins.Application.DTO.LoginModule;
using Logins.Application.DTO.UserModule;
using MediatR;
using Shared.Infra;

var builder = WebApplication.CreateBuilder(args);

LoadEnvironmentVariables();

AddServices(builder);

builder.Configuration.AddEnvironmentVariables();

builder.ConfigureMongoClient();

MongoExtensions.ConfigureBSON();

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

app.Run();

void LoadEnvironmentVariables()
{
    var root = Directory.GetCurrentDirectory();
    var dotenv = Path.Combine(root, ".env");
    DotEnv.Load(dotenv);
}

void AddServices(WebApplicationBuilder builder)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddMediatR(typeof(VerifyUserHandler));
    builder.Services.AddCors(opt => opt.AddPolicy("cors", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
    builder.Services.AddScoped<UserRepository>();
    builder.Services.AddScoped<LoginRepository>();
}