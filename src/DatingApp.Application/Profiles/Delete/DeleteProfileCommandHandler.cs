using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Delete;

public class DeleteProfileCommandHandler(IRepository<Profile> repository) : IRequestHandler<DeleteProfileCommand, ProfileDto?>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<ProfileDto?> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
  {
    var existingProfile = await _repository.GetByIdAsync(request.ProfileId);

    if (existingProfile == null)
    {
      return null;
    }

    await _repository.DeleteAsync(existingProfile.Id);

    return ProfileDto.FromEntity(existingProfile);
  }
}
