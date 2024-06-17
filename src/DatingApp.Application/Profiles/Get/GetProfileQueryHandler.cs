using DatingApp.Application.Common.Enums;
using DatingApp.Application.Common.Models;
using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Get;

public class GetProfileQueryHandler(IRepository<Profile> repository) : IRequestHandler<GetProfileQuery, Result<ProfileDto>>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<Result<ProfileDto>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
  {
    var profile = await _repository.GetByIdAsync(request.ProfileId, cancellationToken);

    if (profile == null)
    {
      return Result.Failure<ProfileDto>(ResultStatus.NotFound, $"{nameof(Profile)} not found.");
    }

    var profileDto = ProfileDto.FromEntity(profile);

    return Result.Success(profileDto);
  }
}
