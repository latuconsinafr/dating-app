using DatingApp.Core.Profiles.Enums;
using DatingApp.Core.Profiles.ValueObjects;

namespace DatingApp.Core.Profiles.Entities;

public class Profile(string firstName, string lastName, ProfileBirthday birthday, ProfileGender gender, ProfileLookingFor lookingFor)
{
  public ProfileId Id { get; private set; } = ProfileId.New();
  public string FirstName { get; private set; } = firstName;
  public string LastName { get; private set; } = lastName;
  public ProfileBirthday Birthday { get; private set; } = birthday;
  public ProfileGender Gender { get; private set; } = gender;
  public ProfileLookingFor LookingFor { get; private set; } = lookingFor;

  public Profile() : this(string.Empty, string.Empty, new(), ProfileGender.None, ProfileLookingFor.None) { }

  public void UpdateLookingFor(ProfileLookingFor lookingFor)
  {
    LookingFor = lookingFor;
  }
}
