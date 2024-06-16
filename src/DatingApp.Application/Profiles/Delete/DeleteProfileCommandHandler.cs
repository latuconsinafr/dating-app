using DatingApp.Application.Common.Enums;
using DatingApp.Application.Common.Models;
using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Delete;

public class DeleteProfileCommandHandler(IRepository<Profile> repository) : IRequestHandler<DeleteProfileCommand, Result<ProfileDto>>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<Result<ProfileDto>> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
  {
    var existingProfile = await _repository.GetByIdAsync(request.ProfileId, cancellationToken);

    if (existingProfile == null)
    {
      return Result.Failure<ProfileDto>(ErrorCode.NotFound);
    }

    await _repository.DeleteAsync(existingProfile.Id, cancellationToken);

    return Result.Success<ProfileDto>();
  }
}
