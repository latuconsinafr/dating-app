using MediatR;

namespace DatingApp.Application.Profiles.Get;

public record GetProfileQuery(Guid ProfileId) : IRequest<ProfileDto>
{
}

