using DatingApp.Application.Profiles;
using DatingApp.Core.Profiles.Enums;

namespace DatingApp.Web.Profiles.Models.Responses;

public class ProfileResponse
{
  public Guid Id { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public ProfileBirthdayResponse Birthday { get; set; } = new();
  public ProfileGender Gender { get; set; }
  public ProfileLookingFor LookingFor { get; set; }

  public static ProfileResponse FromDto(ProfileDto profileDto)
  {
    return new ProfileResponse
    {
      Id = profileDto.Id.Value,
      FirstName = profileDto.FirstName,
      LastName = profileDto.LastName,
      Birthday = ProfileBirthdayResponse.FromDto(profileDto.Birthday),
      Gender = profileDto.Gender,
      LookingFor = profileDto.LookingFor
    };
  }
}

public class ProfileBirthdayResponse
{
  public int Month { get; set; }
  public int Day { get; set; }
  public int Year { get; set; }

  public static ProfileBirthdayResponse FromDto(ProfileBirthdayDto birthdayDto)
  {
    return new ProfileBirthdayResponse
    {
      Month = birthdayDto.Month,
      Day = birthdayDto.Day,
      Year = birthdayDto.Year
    };
  }
}
