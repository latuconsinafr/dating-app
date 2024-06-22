using DatingApp.Application.Profiles.Update;
using DatingApp.Core.Profiles.Enums;

namespace DatingApp.Web.Profiles.Models.Requests;

public class UpdateProfileRequest
{
  public Guid Id { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public CreateProfileBirthdayRequest Birthday { get; set; } = new();
  public ProfileGender Gender { get; set; }
  public ProfileLookingFor LookingFor { get; set; }

  public UpdateProfileCommand ToCommand()
  {
    return new UpdateProfileCommand(Id, LookingFor);
  }
}
