using MediatR;

namespace DatingApp.Application.Profiles.GetAll;

public record GetAllProfilesQuery : IRequest<List<ProfileDto>>
{
}

