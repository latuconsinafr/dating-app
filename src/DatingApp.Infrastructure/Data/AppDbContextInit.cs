using DatingApp.Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Data;

public class AppDbContextInit(AppDbContext context)
{
  private readonly AppDbContext _context = context;

  public async Task InitializeAsync()
  {
    await _context.Database.MigrateAsync();

    await SeedDataAsync();
  }

  public async Task SeedDataAsync()
  {
    bool changesMade = false;

    if (!await _context.Profiles.AnyAsync())
    {
      var profiles = ProfileSeed.GetSeeds();
      _context.Profiles.AddRange(profiles);

      changesMade = true;
    }

    if (changesMade)
    {
      await _context.SaveChangesAsync();
    }
  }
}
