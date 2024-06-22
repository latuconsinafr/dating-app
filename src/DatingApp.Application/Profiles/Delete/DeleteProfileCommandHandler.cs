using DatingApp.Application.Common.Models;
using DatingApp.Core.Profiles.Entities;
using DatingApp.Core.Profiles.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Delete;

public class DeleteProfileCommandHandler(IProfileRepository repository) : IRequestHandler<DeleteProfileCommand, Result<bool>>
{
  private readonly IProfileRepository _repository = repository;

  public async Task<Result<bool>> Handle(DeleteProfileCommand command, CancellationToken cancellationToken)
  {
    var existingProfile = await _repository.GetByIdAsync(command.Id, cancellationToken);

    if (existingProfile == null)
    {
      return Result.Failure<bool>($"{nameof(Profile)} not found.");
    }

    await _repository.DeleteAsync(existingProfile.Id, cancellationToken);

    return Result.Success(true);
  }
}
