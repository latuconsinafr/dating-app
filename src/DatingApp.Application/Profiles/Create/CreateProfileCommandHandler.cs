using DatingApp.Application.Common.Enums;
using DatingApp.Application.Common.Models;
using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Create;

public class CreateProfileCommandHandler(IRepository<Profile> repository) : IRequestHandler<CreateProfileCommand, Result<ProfileDto>>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<Result<ProfileDto>> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
  {
    var profile = request.ToEntity();
    var createdProfile = await _repository.AddAsync(profile, cancellationToken);
    var createdProfileDto = ProfileDto.FromEntity(createdProfile);

    return Result.Success(createdProfileDto, ResultStatus.Created);
  }
}
