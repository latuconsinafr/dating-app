using DatingApp.Application.Common.Enums;
using DatingApp.Application.Common.Models;
using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Update;

public class UpdateProfileCommandHandler(IRepository<Profile> repository) : IRequestHandler<UpdateProfileCommand, Result<ProfileDto>>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<Result<ProfileDto>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
  {
    var existingProfile = await _repository.GetByIdAsync(request.Id);

    if (existingProfile == null)
    {
      return Result.Failure<ProfileDto>(ErrorCode.NotFound);
    }

    existingProfile = request.ToEntity(existingProfile);

    await _repository.UpdateAsync(existingProfile, cancellationToken);

    var updateProfileDto = ProfileDto.FromEntity(existingProfile);

    return Result.Success(updateProfileDto);
  }
}
