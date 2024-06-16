using DatingApp.Application.Common.Models;
using MediatR;

namespace DatingApp.Application.Profiles.GetAll;

public record GetAllProfilesQuery : IRequest<Result<IEnumerable<ProfileDto>>>
{
}

