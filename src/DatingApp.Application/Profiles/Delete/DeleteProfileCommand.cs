using DatingApp.Application.Common.Models;
using DatingApp.Core.Profiles.ValueObjects;
using MediatR;

namespace DatingApp.Application.Profiles.Delete;

public record DeleteProfileCommand(ProfileId Id) : IRequest<Result<bool>>
{
}

