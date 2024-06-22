using DatingApp.Core.Common.Repositories;
using DatingApp.Core.Profiles.Repositories;
using DatingApp.Infrastructure.Data;
using DatingApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.Infrastructure;

public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
  {
    string? connectionString = config.GetConnectionString("DefaultConnection");

    if (string.IsNullOrEmpty(connectionString))
    {
      throw new ArgumentNullException("DefaultConnection", "Connection string 'DefaultConnection' not found.");
    }

    services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

    services.AddScoped<AppDbContextInit>();
    services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

    services.AddScoped<IProfileRepository, ProfileRepository>();

    return services;
  }
}
