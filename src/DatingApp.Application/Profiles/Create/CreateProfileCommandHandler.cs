using DatingApp.Application.Common.Models;
using DatingApp.Core.Profiles.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Create;

public class CreateProfileCommandHandler(IProfileRepository repository) : IRequestHandler<CreateProfileCommand, Result<ProfileDto>>
{
  private readonly IProfileRepository _repository = repository;

  public async Task<Result<ProfileDto>> Handle(CreateProfileCommand command, CancellationToken cancellationToken)
  {
    var profile = command.ToEntity();
    var createdProfile = await _repository.AddAsync(profile, cancellationToken);
    var createdProfileDto = ProfileDto.FromEntity(createdProfile);

    return Result.Success(createdProfileDto);
  }
}
