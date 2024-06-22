using DatingApp.Application.Common.Models;
using DatingApp.Core.Profiles.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.GetAll;

public class GetAllProfilesQueryHandler(IProfileRepository repository) : IRequestHandler<GetAllProfilesQuery, Result<IReadOnlyList<ProfileDto>>>
{
  private readonly IProfileRepository _repository = repository;

  public async Task<Result<IReadOnlyList<ProfileDto>>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
  {
    var profiles = await _repository.GetAllAsync(cancellationToken);
    IReadOnlyList<ProfileDto> profileDtos = profiles.Select(ProfileDto.FromEntity).ToList().AsReadOnly();

    return Result.Success(profileDtos);
  }
}
