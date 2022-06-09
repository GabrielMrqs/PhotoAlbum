using Microsoft.EntityFrameworkCore;
using Shared.Infra;
using MediatR;
using Albums.Infra.AlbumModule;
using PhotoAlbum.Application.PhotoModule;
using PhotoAlbum.Application.PhotoModule.DTO_s;

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

app.MapGet("/getAlbum/{clientId}", async (IMediator mediator, Guid clientId) =>
{
    return await mediator.Send(new GetPhotoAlbumRequest(clientId));
})
.WithName("Get client's Album");

app.MapPut("/addPhoto", async (IMediator mediator, AddPhotoDTO addphoto) =>
{
    await mediator.Send(new AddPhotoRequest(addphoto));
})
.WithName("Add photo");

await ApplyMigrations();

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
    builder.Services.AddAutoMapper(typeof(GetPhotoAlbumHandler));
    builder.Services.AddMediatR(typeof(GetPhotoAlbumHandler));
    builder.Services.AddCors(opt => opt.AddPolicy("cors", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
    //builder.Services.AddScoped<BaseRepository<Client>>();
    builder.Services.AddScoped<AlbumRepository>();
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

async Task ApplyMigrations()
{
    using var scope = app.Services.CreateAsyncScope();
    await scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.MigrateAsync();
}