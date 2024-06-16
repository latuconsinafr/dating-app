using System.Reflection;
using DatingApp.Application.Profiles;
using DatingApp.Application.Profiles.Create;
using DatingApp.Application.Profiles.Delete;
using DatingApp.Application.Profiles.Get;
using DatingApp.Application.Profiles.GetAll;
using DatingApp.Application.Profiles.Update;
using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Infrastructure;
using DatingApp.Infrastructure.Data;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(builder.Configuration);

ConfigureMediatR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  await InitializeDatabaseAsync(app);
}
else
{
  app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

static async Task InitializeDatabaseAsync(WebApplication app)
{
  using var scope = app.Services.CreateScope();
  var services = scope.ServiceProvider;

  try
  {
    var initializer = services.GetRequiredService<AppDbContextInit>();

    await initializer.InitializeAsync();
  }
  catch (Exception ex)
  {
    Console.WriteLine($"An error occurred while initializing the database: {ex.Message}");
  }
}

void ConfigureMediatR()
{
  var assembles = new[] {
    // Core
    Assembly.GetAssembly(typeof(Profile)),

    // Application
  };

  builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(assembles!));

  // Request handler
  builder.Services.AddTransient<IRequestHandler<GetAllProfilesQuery, List<ProfileDto>>, GetAllProfilesQueryHandler>();
  builder.Services.AddTransient<IRequestHandler<GetProfileQuery, ProfileDto?>, GetProfileQueryHandler>();
  builder.Services.AddTransient<IRequestHandler<CreateProfileCommand, ProfileDto>, CreateProfileCommandHandler>();
  builder.Services.AddTransient<IRequestHandler<UpdateProfileCommand, ProfileDto?>, UpdateProfileCommandHandler>();
  builder.Services.AddTransient<IRequestHandler<DeleteProfileCommand, ProfileDto?>, DeleteProfileCommandHandler>();
}

app.Run();
