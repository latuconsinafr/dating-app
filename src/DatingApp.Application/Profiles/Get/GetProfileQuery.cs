using DatingApp.Application.Common.Models;
using DatingApp.Core.Profiles.ValueObjects;
using MediatR;

namespace DatingApp.Application.Profiles.Get;

public record GetProfileQuery(ProfileId Id) : IRequest<Result<ProfileDto>>
{
}

