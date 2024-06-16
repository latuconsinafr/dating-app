using DatingApp.Core.Aggregates.Profiles.Enums;
using DatingApp.Core.Aggregates.Profiles.ValueObjects;

namespace DatingApp.Core.Aggregates.Profiles.Entities;

public class Profile(string firstName, string lastName, Birthday birthday, ProfileGender gender, ProfileLookingFor lookingFor)
{
  public Guid Id { get; private set; } = Guid.NewGuid();
  public string FirstName { get; private set; } = firstName;
  public string LastName { get; private set; } = lastName;
  public Birthday Birthday { get; private set; } = birthday;
  public ProfileGender Gender { get; private set; } = gender;
  public ProfileLookingFor LookingFor { get; private set; } = lookingFor;

  public Profile() : this(string.Empty, string.Empty, new(), ProfileGender.None, ProfileLookingFor.None) { }

  public void UpdateLookingFor(ProfileLookingFor lookingFor)
  {
    LookingFor = lookingFor;
  }
}
