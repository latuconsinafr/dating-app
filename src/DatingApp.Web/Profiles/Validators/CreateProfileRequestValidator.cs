using DatingApp.Core.Profiles;
using DatingApp.Web.Profiles.Models.Requests;
using FluentValidation;

namespace DatingApp.Web.Profiles.Validators;

public class CreateProfileRequestValidator : AbstractValidator<CreateProfileRequest>
{
  public CreateProfileRequestValidator()
  {
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
