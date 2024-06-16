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
      var profiles = await _mediator.Send(new GetAllProfilesQuery());

      return Ok(profiles);
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
      var profile = await _mediator.Send(new GetProfileQuery(id));

      if (profile == null)
      {
        return NotFound();
      }

      return Ok(profile);
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
      var createdProfile = await _mediator.Send(command);

      return StatusCode(201, createdProfile);
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

      var updatedProfile = await _mediator.Send(command);

      if (updatedProfile == null)
      {
        return NotFound();
      }

      return Ok(updatedProfile);
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
      var profile = await _mediator.Send(new DeleteProfileCommand(id));

      if (profile == null)
      {
        return NotFound();
      }

      return NoContent();
    }
    catch (Exception ex)
    {
      return StatusCode(500, ex.Message);
    }
  }
}
