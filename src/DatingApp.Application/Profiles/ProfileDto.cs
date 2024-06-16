using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Aggregates.Profiles.Enums;
using DatingApp.Core.Aggregates.Profiles.ValueObjects;

namespace DatingApp.Application.Profiles;

public class ProfileDto
{
  public Guid Id { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public BirthdayDto Birthday { get; set; } = new();
  public ProfileGender Gender { get; set; }
  public ProfileLookingFor LookingFor { get; set; }

  public static ProfileDto FromEntity(Profile profile)
  {
    return new ProfileDto
    {
      Id = profile.Id,
      FirstName = profile.FirstName,
      LastName = profile.LastName,
      Birthday = BirthdayDto.FromEntity(profile.Birthday),
      Gender = profile.Gender,
      LookingFor = profile.LookingFor
    };
  }
}


public class BirthdayDto
{
  public int Month { get; set; }
  public int Day { get; set; }
  public int Year { get; set; }

  public static BirthdayDto FromEntity(Birthday birthday)
  {
    return new BirthdayDto
    {
      Month = birthday.Month,
      Day = birthday.Day,
      Year = birthday.Year
    };
  }
}
