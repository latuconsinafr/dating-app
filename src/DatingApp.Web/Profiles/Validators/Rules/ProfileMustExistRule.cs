using DatingApp.Application.Profiles.Get;
using FluentValidation;
using MediatR;

namespace DatingApp.Web.Profiles.Validators.Rules;

public static class ProfileMustExistRule
{
  public static IRuleBuilder<T, Guid> ProfileMustExist<T>(
    this IRuleBuilder<T, Guid> ruleBuilder,
    IMediator mediator
  )
  {
    return ruleBuilder.Must((id) =>
    {
      var result = mediator.Send(new GetProfileQuery(new(id))).Result;

      return result.IsSuccess && result.Value is not null;
    })
    .WithMessage("'{PropertyName}' must be exist.");
  }

  public static IRuleBuilder<T, Guid> ProfileMustExistAsync<T>(
    this IRuleBuilder<T, Guid> ruleBuilder,
    IMediator mediator
  )
  {
    return ruleBuilder.MustAsync(async (id, cancellation) =>
    {
      var result = await mediator.Send(new GetProfileQuery(new(id)), cancellation);

      return result.IsSuccess && result.Value is not null;
    })
    .WithMessage("'{PropertyName}' must be exist.");
  }
}
