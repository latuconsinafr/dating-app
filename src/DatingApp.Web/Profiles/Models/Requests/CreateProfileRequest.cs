using DatingApp.Application.Profiles.Create;
using DatingApp.Core.Profiles.Enums;

namespace DatingApp.Web.Profiles.Models.Requests;

public class CreateProfileRequest
{
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public CreateProfileBirthdayRequest Birthday { get; set; } = new();
  public ProfileGender Gender { get; set; }
  public ProfileLookingFor LookingFor { get; set; }

  public CreateProfileCommand ToCommand()
  {
    return new CreateProfileCommand(FirstName, LastName, Gender, LookingFor);
  }
}

public class CreateProfileBirthdayRequest
{
  public int Month { get; private set; }
  public int Day { get; private set; }
  public int Year { get; private set; }
}
