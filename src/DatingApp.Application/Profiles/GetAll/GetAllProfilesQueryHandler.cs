using DatingApp.Application.Common.Models;
using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.GetAll;

public class GetAllProfilesQueryHandler(IRepository<Profile> repository) : IRequestHandler<GetAllProfilesQuery, Result<IEnumerable<ProfileDto>>>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<Result<IEnumerable<ProfileDto>>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
  {
    var profiles = await _repository.GetAllAsync(cancellationToken);
    var profileDtos = profiles.Select(ProfileDto.FromEntity);

    return Result.Success(profileDtos);
  }
}
