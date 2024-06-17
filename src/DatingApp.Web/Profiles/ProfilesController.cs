using DatingApp.Application.Profiles;
using DatingApp.Application.Profiles.Create;
using DatingApp.Application.Profiles.Delete;
using DatingApp.Application.Profiles.Get;
using DatingApp.Application.Profiles.GetAll;
using DatingApp.Application.Profiles.Update;
using DatingApp.Web.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Web.Profiles;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController(IMediator mediator) : ControllerBase
{
  private readonly IMediator _mediator = mediator;

  [HttpGet]
  public async Task<ActionResult<IEnumerable<ProfileDto>>> GetAllProfiles()
  {
    try
    {
      var result = await _mediator.Send(new GetAllProfilesQuery());

      return ResponseWrapper.Return(HttpContext, result);
    }
    catch (Exception ex)
    {
      return ResponseWrapper.Error(HttpContext, ex.Message);
    }
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ProfileDto>> GetProfile(Guid id)
  {
    try
    {
      var result = await _mediator.Send(new GetProfileQuery(id));

      return ResponseWrapper.Return(HttpContext, result);
    }
    catch (Exception ex)
    {
      return ResponseWrapper.Error(HttpContext, ex.Message);
    }
  }

  [HttpPost]
  public async Task<ActionResult<ProfileDto>> CreateProfile(CreateProfileCommand command)
  {
    try
    {
      var result = await _mediator.Send(command);

      return ResponseWrapper.Return(HttpContext, result);
    }
    catch (Exception ex)
    {
      return ResponseWrapper.Error(HttpContext, ex.Message);
    }
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<ProfileDto>> UpdateProfile(Guid id, UpdateProfileCommand command)
  {
    try
    {
      if (id != command.Id)
      {
        return Conflict();
      }

      var result = await _mediator.Send(command);

      return ResponseWrapper.Return(HttpContext, result);
    }
    catch (Exception ex)
    {
      return ResponseWrapper.Error(HttpContext, ex.Message);
    }
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteProfile(Guid id)
  {
    try
    {
      var result = await _mediator.Send(new DeleteProfileCommand(id));

      return ResponseWrapper.Return(HttpContext, result);
    }
    catch (Exception ex)
    {
      return ResponseWrapper.Error(HttpContext, ex.Message);
    }
  }
}
