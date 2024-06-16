using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.GetAll;

public class GetAllProfilesQueryHandler(IRepository<Profile> repository) : IRequestHandler<GetAllProfilesQuery, List<ProfileDto>>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<List<ProfileDto>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
  {
    var profiles = await _repository.GetAllAsync();

    return profiles.Select(ProfileDto.FromEntity).ToList();
  }
}
