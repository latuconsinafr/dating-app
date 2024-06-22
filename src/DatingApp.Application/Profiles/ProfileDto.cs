using DatingApp.Core.Profiles.Entities;
using DatingApp.Core.Profiles.Enums;
using DatingApp.Core.Profiles.ValueObjects;

namespace DatingApp.Application.Profiles;

public class ProfileDto
{
  public ProfileId Id { get; set; } = ProfileId.New();
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public ProfileBirthdayDto Birthday { get; set; } = new();
  public ProfileGender Gender { get; set; } = ProfileGender.None;
  public ProfileLookingFor LookingFor { get; set; } = ProfileLookingFor.None;

  public static ProfileDto FromEntity(Profile profile)
  {
    return new ProfileDto
    {
      Id = profile.Id,
      FirstName = profile.FirstName,
      LastName = profile.LastName,
      Birthday = ProfileBirthdayDto.FromEntity(profile.Birthday),
      Gender = profile.Gender,
      LookingFor = profile.LookingFor
    };
  }
}

public class ProfileBirthdayDto
{
  public int Month { get; set; }
  public int Day { get; set; }
  public int Year { get; set; }

  public static ProfileBirthdayDto FromEntity(ProfileBirthday birthday)
  {
    return new ProfileBirthdayDto
    {
      Month = birthday.Month,
      Day = birthday.Day,
      Year = birthday.Year
    };
  }
}
