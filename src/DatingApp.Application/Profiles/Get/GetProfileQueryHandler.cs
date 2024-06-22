using DatingApp.Application.Common.Models;
using DatingApp.Core.Profiles.Entities;
using DatingApp.Core.Profiles.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Get;

public class GetProfileQueryHandler(IProfileRepository repository) : IRequestHandler<GetProfileQuery, Result<ProfileDto>>
{
  private readonly IProfileRepository _repository = repository;

  public async Task<Result<ProfileDto>> Handle(GetProfileQuery query, CancellationToken cancellationToken)
  {
    var profile = await _repository.GetByIdAsync(query.Id, cancellationToken);

    if (profile == null)
    {
      return Result.Failure<ProfileDto>($"{nameof(Profile)} not found.");
    }

    var profileDto = ProfileDto.FromEntity(profile);

    return Result.Success(profileDto);
  }
}
