using DatingApp.Core.Profiles;
using DatingApp.Web.Profiles.Models.Requests;
using DatingApp.Web.Profiles.Validators.Rules;
using FluentValidation;
using MediatR;

namespace DatingApp.Web.Profiles.Validators;

public class UpdateProfileRequestValidator : AbstractValidator<UpdateProfileRequest>
{
  public UpdateProfileRequestValidator(IMediator mediator)
  {
    RuleFor(x => x.Id)
      .NotEmpty()
      .ProfileMustExistAsync(mediator);

    RuleFor(x => x.FirstName)
      .NotEmpty()
      .MaximumLength(ProfileConstants.FIRST_NAME_MAX_LENGTH);

    RuleFor(x => x.LastName)
      .NotEmpty()
      .MaximumLength(ProfileConstants.LAST_NAME_MAX_LENGTH);

    RuleFor(x => x.Birthday)
      .NotEmpty();

    RuleFor(x => x.Gender)
      .NotEmpty()
      .IsInEnum();

    RuleFor(x => x.LookingFor)
      .NotEmpty()
      .IsInEnum();
  }
}
