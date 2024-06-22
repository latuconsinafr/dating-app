using System.Reflection;
using DatingApp.Application.Common.Models;
using DatingApp.Application.Profiles;
using DatingApp.Application.Profiles.Create;
using DatingApp.Application.Profiles.Delete;
using DatingApp.Application.Profiles.Get;
using DatingApp.Application.Profiles.GetAll;
using DatingApp.Application.Profiles.Update;
using DatingApp.Core.Profiles.Entities;
using DatingApp.Infrastructure;
using DatingApp.Infrastructure.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("v1", new OpenApiInfo
  {
    Version = "v1",
    Title = "Dating App API",
    Description = "A dating app API for online dating service",
    Contact = new OpenApiContact
    {
      Name = "Farista Latuconsina",
      Url = new Uri("https://github.com/latuconsinafr")
    },
    License = new OpenApiLicense
    {
      Name = "MIT",
      Url = new Uri("https://github.com/latuconsinafr/dating-app/blob/main/LICENSE")
    }
  });

  var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationRulesToSwagger();

ConfigureMediatR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  await InitializeDatabaseAsync(app);

  app.UseSwagger();
  app.UseSwaggerUI();
}
else
{
  app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

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
  builder.Services.AddTransient<IRequestHandler<GetAllProfilesQuery, Result<IReadOnlyList<ProfileDto>>>, GetAllProfilesQueryHandler>();
  builder.Services.AddTransient<IRequestHandler<GetProfileQuery, Result<ProfileDto>>, GetProfileQueryHandler>();
  builder.Services.AddTransient<IRequestHandler<CreateProfileCommand, Result<ProfileDto>>, CreateProfileCommandHandler>();
  builder.Services.AddTransient<IRequestHandler<UpdateProfileCommand, Result<ProfileDto>>, UpdateProfileCommandHandler>();
  builder.Services.AddTransient<IRequestHandler<DeleteProfileCommand, Result<bool>>, DeleteProfileCommandHandler>();
}
