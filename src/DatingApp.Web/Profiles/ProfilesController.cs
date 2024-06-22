using DatingApp.Application.Profiles.Delete;
using DatingApp.Application.Profiles.Get;
using DatingApp.Application.Profiles.GetAll;
using DatingApp.Web.Common.Controllers;
using DatingApp.Web.Common.Models;
using DatingApp.Web.Profiles.Models.Requests;
using DatingApp.Web.Profiles.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Web.Profiles;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController(IMediator mediator) : BaseController
{
  private readonly IMediator _mediator = mediator;

  /// <summary>
  /// Gets all profiles.
  /// </summary>
  /// <returns>List of profiles.</returns>
  /// <remarks>
  /// Gets all profile.
  /// </remarks>
  /// <response code="200">Returns a list of all profiles.</response>
  /// <response code="404">If there is no profile found.</response>
  /// <response code="500">If any error happens.</response>
  [HttpGet]
  [ProducesResponseType<Response<IReadOnlyList<ProfileResponse>>>(StatusCodes.Status200OK)]
  [ProducesResponseType<Response>(StatusCodes.Status404NotFound)]
  [ProducesResponseType<Response>(StatusCodes.Status500InternalServerError)]
  public async Task<ActionResult<IReadOnlyList<ProfileResponse>>> GetAllProfiles()
  {
    try
    {
      var query = new GetAllProfilesQuery();
      var result = await _mediator.Send(query);

      if (result.Value == null || !result.Value.Any())
      {
        return NotFoundResponse();
      }

      var response = result.Value.Select(ProfileResponse.FromDto).ToList();
      return OkResponse(response);
    }
    catch (Exception ex)
    {
      return InternalServerErrorResponse(ex.Message);
    }
  }

  /// <summary>
  /// Gets a specified profile.
  /// </summary>
  /// <param name="id">The given id of profile to get</param>
  /// <returns>A specified profile.</returns>
  /// <remarks>
  /// Get a specified profile by a given id.
  /// </remarks>
  /// <response code="200">Returns a specified profile.</response>
  /// <response code="404">If profile with the given id is not found.</response>
  /// <response code="500">If any error happens.</response>
  [HttpGet("{id}")]
  [ProducesResponseType<Response<ProfileResponse>>(StatusCodes.Status200OK)]
  [ProducesResponseType<Response>(StatusCodes.Status404NotFound)]
  [ProducesResponseType<Response>(StatusCodes.Status500InternalServerError)]
  public async Task<ActionResult<ProfileResponse>> GetProfile(Guid id)
  {
    try
    {
      var query = new GetProfileQuery(new(id));
      var result = await _mediator.Send(query);

      if (result.Value == null)
      {
        return NotFoundResponse(result.Message);
      }

      var response = ProfileResponse.FromDto(result.Value);
      return OkResponse(response);
    }
    catch (Exception ex)
    {
      return InternalServerErrorResponse(ex.Message);
    }
  }

  /// <summary>
  /// Creates a profile.
  /// </summary>
  /// <param name="request">The request to create a profile.</param>
  /// <returns>The created profile.</returns>
  /// <remarks>
  /// Creates a profile.
  /// </remarks>
  /// <response code="201">Returns the created profile.</response>
  /// <response code="400">If the input validation failed.</response>
  /// <response code="500">If any error happens.</response>
  [HttpPost]
  [ProducesResponseType<Response<ProfileResponse>>(StatusCodes.Status201Created)]
  [ProducesResponseType<Response>(StatusCodes.Status400BadRequest)]
  [ProducesResponseType<Response>(StatusCodes.Status500InternalServerError)]
  public async Task<ActionResult<ProfileResponse>> CreateProfile(CreateProfileRequest request)
  {
    try
    {
      var command = request.ToCommand();
      var result = await _mediator.Send(command);

      // * TODO: This will be validation error
      if (result.Value == null)
      {
        return InternalServerErrorResponse(result.Message);
      }

      var response = ProfileResponse.FromDto(result.Value);
      return CreatedResponse(response);
    }
    catch (Exception ex)
    {
      return InternalServerErrorResponse(ex.Message);
    }
  }

  /// <summary>
  /// Updates a specified profile.
  /// </summary>
  /// <param name="id">The given id of profile to update.</param>
  /// <param name="request">The request to update a profile.</param>
  /// <returns>The updated profile.</returns>
  /// <remarks>
  /// Updates a specified profile by a given id.
  /// </remarks>
  /// <response code="200">Returns a specified profile.</response>
  /// <response code="400">If the input validation failed.</response>
  /// <response code="404">If profile with the given id is not found.</response>
  /// <response code="500">If any error happens.</response>
  [HttpPut("{id}")]
  [ProducesResponseType<Response<IEnumerable<ProfileResponse>>>(StatusCodes.Status200OK)]
  [ProducesResponseType<Response>(StatusCodes.Status400BadRequest)]
  [ProducesResponseType<Response>(StatusCodes.Status404NotFound)]
  [ProducesResponseType<Response>(StatusCodes.Status500InternalServerError)]
  public async Task<ActionResult<ProfileResponse>> UpdateProfile(Guid id, UpdateProfileRequest request)
  {
    try
    {
      if (id != request.Id)
      {
        return ConflictResponse();
      }

      var command = request.ToCommand();
      var result = await _mediator.Send(command);

      if (result.Value == null)
      {
        return NotFoundResponse(result.Message);
      }

      var response = ProfileResponse.FromDto(result.Value);
      return OkResponse(response);
    }
    catch (Exception ex)
    {
      return InternalServerErrorResponse(ex.Message);
    }
  }

  /// <summary>
  /// Deletes a specified profile.
  /// </summary>
  /// <param name="id">The given id of profile to delete.</param>
  /// <remarks>
  /// Deletes a specified profile by a given id.
  /// </remarks>
  /// <response code="204">Returns nothing when a specified profile successfully deleted.</response>
  /// <response code="404">If profile with the given id is not found.</response>
  /// <response code="500">If any error happens.</response>
  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType<Response>(StatusCodes.Status404NotFound)]
  [ProducesResponseType<Response>(StatusCodes.Status500InternalServerError)]
  public async Task<ActionResult> DeleteProfile(Guid id)
  {
    try
    {
      var command = new DeleteProfileCommand(new(id));
      var result = await _mediator.Send(command);

      if (!result.Value)
      {
        return NotFoundResponse(result.Message);
      }

      return NoContentResponse();
    }
    catch (Exception ex)
    {
      return InternalServerErrorResponse(ex.Message);
    }
  }
}
