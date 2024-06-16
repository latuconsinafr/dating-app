using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Aggregates.Profiles.Enums;
using DatingApp.Core.Aggregates.Profiles.ValueObjects;

namespace DatingApp.Infrastructure.Data.Seeds;

public static class ProfileSeed
{
  public static Profile[] GetSeeds()
  {
    return [
      new("Farista", "Latuconsina", new Birthday(8, 6, 1995), ProfileGender.Man, ProfileLookingFor.ImNotSureYet),
      new("Raden", "Saleh", new Birthday(1, 2, 2002), ProfileGender.Man, ProfileLookingFor.Relationship),
      new("Anisa", "Soebandono", new Birthday(12, 5, 1990), ProfileGender.Woman, ProfileLookingFor.Relationship),
    ];
  }
}
