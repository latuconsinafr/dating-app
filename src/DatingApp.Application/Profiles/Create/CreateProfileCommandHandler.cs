using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Create;

public class CreateProfileCommandHandler(IRepository<Profile> repository) : IRequestHandler<CreateProfileCommand, ProfileDto>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<ProfileDto> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
  {
    var profile = request.ToEntity();
    var createdProfile = await _repository.AddAsync(profile);

    return ProfileDto.FromEntity(createdProfile);
  }
}
