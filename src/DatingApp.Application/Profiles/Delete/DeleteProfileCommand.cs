using MediatR;

namespace DatingApp.Application.Profiles.Delete;

public record DeleteProfileCommand(Guid ProfileId) : IRequest<ProfileDto?>
{
}

