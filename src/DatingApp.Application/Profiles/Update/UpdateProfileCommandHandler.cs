using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Update;

public class UpdateProfileCommandHandler(IRepository<Profile> repository) : IRequestHandler<UpdateProfileCommand, ProfileDto?>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<ProfileDto?> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
  {
    var existingProfile = await _repository.GetByIdAsync(request.Id);

    if (existingProfile == null)
    {
      return null;
    }

    existingProfile = request.ToEntity(existingProfile);

    await _repository.UpdateAsync(existingProfile);

    return ProfileDto.FromEntity(existingProfile);
  }
}
