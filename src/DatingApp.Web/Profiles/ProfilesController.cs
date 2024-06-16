using DatingApp.Application.Common.Enums;
using DatingApp.Application.Profiles;
using DatingApp.Application.Profiles.Create;
using DatingApp.Application.Profiles.Delete;
using DatingApp.Application.Profiles.Get;
using DatingApp.Application.Profiles.GetAll;
using DatingApp.Application.Profiles.Update;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Web.Profiles;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController(IMediator mediator) : ControllerBase
{
  private readonly IMediator _mediator = mediator;

  [HttpGet]
  public async Task<ActionResult<List<ProfileDto>>> GetAllProfiles()
  {
    try
    {
      var result = await _mediator.Send(new GetAllProfilesQuery());

      return Ok(result.Value);
    }
    catch (Exception ex)
    {
      return StatusCode(500, ex.Message);
    }
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ProfileDto>> GetProfile(Guid id)
  {
    try
    {
      var result = await _mediator.Send(new GetProfileQuery(id));

      if (result.IsSuccess)
      {
        return Ok(result.Value);
      }

      if (result.Error == ErrorCode.NotFound)
      {
        return NotFound();
      }

      return StatusCode(500, result);
    }
    catch (Exception ex)
    {
      return StatusCode(500, ex.Message);
    }
  }

  [HttpPost]
  public async Task<ActionResult<ProfileDto>> CreateProfile(CreateProfileCommand command)
  {
    try
    {
      var result = await _mediator.Send(command);

      return StatusCode(201, result.Value);
    }
    catch (Exception ex)
    {
      return StatusCode(500, ex.Message);
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

      if (result.IsSuccess)
      {
        return Ok(result.Value);
      }

      if (result.Error == ErrorCode.NotFound)
      {
        return NotFound();
      }

      return StatusCode(500, result);
    }
    catch (Exception ex)
    {
      return StatusCode(500, ex.Message);
    }
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<ProfileDto>> DeleteProfile(Guid id)
  {
    try
    {
      var result = await _mediator.Send(new DeleteProfileCommand(id));

      if (result.IsSuccess)
      {
        return NoContent();
      }

      if (result.Error == ErrorCode.NotFound)
      {
        return NotFound();
      }

      return StatusCode(500, result);
    }
    catch (Exception ex)
    {
      return StatusCode(500, ex.Message);
    }
  }
}
