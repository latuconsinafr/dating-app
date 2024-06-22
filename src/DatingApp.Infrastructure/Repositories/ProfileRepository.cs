using DatingApp.Core.Profiles.Entities;
using DatingApp.Core.Profiles.Repositories;
using DatingApp.Core.Profiles.ValueObjects;
using DatingApp.Infrastructure.Data;

namespace DatingApp.Infrastructure.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
  private readonly AppDbContext _context = context;

  public async Task<Profile?> GetByIdAsync(ProfileId id, CancellationToken cancellationToken = default)
  {
    return await _context.Set<Profile>().FindAsync([id.Value], cancellationToken: cancellationToken);
  }

  public async Task DeleteAsync(ProfileId id, CancellationToken cancellationToken = default)
  {
    var profile = await GetByIdAsync(id, cancellationToken);

    if (profile != null)
    {
      _context.Set<Profile>().Remove(profile);
      await _context.SaveChangesAsync(cancellationToken);
    }
  }
}
