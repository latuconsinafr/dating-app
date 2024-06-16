using DatingApp.Application.Common.Models;
using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Aggregates.Profiles.Enums;
using MediatR;

namespace DatingApp.Application.Profiles.Update;

public class UpdateProfileCommand(Guid id, ProfileLookingFor lookingFor) : IRequest<Result<ProfileDto>>
{
  public Guid Id { get; private set; } = id;
  public ProfileLookingFor LookingFor { get; private set; } = lookingFor;

  public Profile ToEntity(Profile existingProfile)
  {
    existingProfile.UpdateLookingFor(LookingFor);

    return existingProfile;
  }
}
