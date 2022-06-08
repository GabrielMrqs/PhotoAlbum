using Albums.Infra.ClientModule;
using Login.Application;
using Login.Application.DTO.ClientModule;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
LoadEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(VerifyClientHandler));
builder.Services.AddCors(opt => opt.AddPolicy("a", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("a");

app.UseHttpsRedirection();

app.MapPost("/verifyClient", async (IMediator mediator, ClientDTO client) =>
{
    var response = await mediator.Send(new VerifyClientRequest(client));
})
.WithName("Send Verification");

app.MapPost("/addClient", async (IMediator mediator, ClientDTO client) =>
{
    var response = await mediator.Send(new AddClientRequest(client));
})
.WithName("Add Client");

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