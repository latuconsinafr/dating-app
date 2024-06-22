using DatingApp.Core.Profiles.Entities;
using DatingApp.Core.Profiles.Enums;
using DatingApp.Core.Profiles.ValueObjects;

namespace DatingApp.Infrastructure.Data.Seeds;

public static class ProfileSeed
{
  public static Profile[] GetSeeds()
  {
    return [
      new("Farista", "Latuconsina", new ProfileBirthday(8, 6, 1995), ProfileGender.Man, ProfileLookingFor.ImNotSureYet),
      new("Raden", "Saleh", new ProfileBirthday(1, 2, 2002), ProfileGender.Man, ProfileLookingFor.Relationship),
      new("Anisa", "Soebandono", new ProfileBirthday(12, 5, 1990), ProfileGender.Woman, ProfileLookingFor.Relationship),
    ];
  }
}
