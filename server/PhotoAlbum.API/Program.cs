using Albums.Infra.UserModule;
using MediatR;
using PhotoAlbum.Application.PhotoModule;
using PhotoAlbum.Application.PhotoModule.DTO_s;
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

app.MapGet("/getAlbum/{userId}", async (IMediator mediator, Guid userId) =>
{
    return await mediator.Send(new GetPhotoAlbumRequest(userId));
})
.WithName("Get user's Album");

app.MapPut("/addPhoto", async (IMediator mediator, AddPhotoDTO addphoto) =>
{
    await mediator.Send(new AddPhotoRequest(addphoto));
})
.WithName("Add photo");

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
    builder.Services.AddScoped<UserRepository>();
}