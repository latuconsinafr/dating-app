using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Get;

public class GetProfileQueryHandler(IRepository<Profile> repository) : IRequestHandler<GetProfileQuery, ProfileDto?>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<ProfileDto?> Handle(GetProfileQuery request, CancellationToken cancellationToken)
  {
    var profile = await _repository.GetByIdAsync(request.ProfileId);

    if (profile == null)
    {
      return null;
    }

    return ProfileDto.FromEntity(profile);
  }
}
