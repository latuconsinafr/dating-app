using DatingApp.Application.Common.Models;
using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Aggregates.Profiles.Enums;
using MediatR;

namespace DatingApp.Application.Profiles.Create;

public class CreateProfileCommand(string firstName, string lastName, ProfileGender gender, ProfileLookingFor lookingFor) : IRequest<Result<ProfileDto>>
{
  public string FirstName { get; private set; } = firstName;
  public string LastName { get; private set; } = lastName;
  public ProfileGender Gender { get; private set; } = gender;
  public ProfileLookingFor LookingFor { get; private set; } = lookingFor;

  public Profile ToEntity()
  {
    return new Profile(
      FirstName,
      LastName,
      new(),
      Gender,
      LookingFor
    );
  }
}
