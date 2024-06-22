using DatingApp.Application.Common.Models;
using DatingApp.Core.Profiles.Entities;
using DatingApp.Core.Profiles.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Update;

public class UpdateProfileCommandHandler(IProfileRepository repository) : IRequestHandler<UpdateProfileCommand, Result<ProfileDto>>
{
  private readonly IProfileRepository _repository = repository;

  public async Task<Result<ProfileDto>> Handle(UpdateProfileCommand command, CancellationToken cancellationToken)
  {
    var existingProfile = await _repository.GetByIdAsync(command.Id);

    if (existingProfile == null)
    {
      return Result.Failure<ProfileDto>($"{nameof(Profile)} not found.");
    }

    existingProfile = command.ToEntity(existingProfile);

    await _repository.UpdateAsync(existingProfile, cancellationToken);

    var updateProfileDto = ProfileDto.FromEntity(existingProfile);

    return Result.Success(updateProfileDto);
  }
}
