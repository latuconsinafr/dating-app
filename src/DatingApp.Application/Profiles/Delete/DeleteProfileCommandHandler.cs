﻿using DatingApp.Application.Common.Enums;
using DatingApp.Application.Common.Models;
using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Repositories;
using MediatR;

namespace DatingApp.Application.Profiles.Delete;

public class DeleteProfileCommandHandler(IRepository<Profile> repository) : IRequestHandler<DeleteProfileCommand, Result>
{
  private readonly IRepository<Profile> _repository = repository;

  public async Task<Result> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
  {
    var existingProfile = await _repository.GetByIdAsync(request.ProfileId, cancellationToken);

    if (existingProfile == null)
    {
      return Result.Failure(ResultStatus.NotFound, $"{nameof(Profile)} not found.");
    }

    await _repository.DeleteAsync(existingProfile.Id, cancellationToken);

    return Result.Success();
  }
}
