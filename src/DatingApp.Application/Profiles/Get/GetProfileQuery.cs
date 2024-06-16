using DatingApp.Application.Common.Models;
using MediatR;

namespace DatingApp.Application.Profiles.Get;

public record GetProfileQuery(Guid ProfileId) : IRequest<Result<ProfileDto>>
{
}

