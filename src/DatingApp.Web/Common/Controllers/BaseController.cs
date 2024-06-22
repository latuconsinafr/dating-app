using DatingApp.Web.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Web.Common.Controllers
{
  public abstract class BaseController : ControllerBase
  {
    private ObjectResult CreateResponse<T>(T data, int statusCode, string? message = null, bool isSuccess = true)
    {
      var response = new Response<T>
      {
        StatusCode = statusCode,
        Path = HttpContext.Request.Path,
        Data = data,
        Message = message,
        IsSuccess = isSuccess
      };

      return new ObjectResult(response) { StatusCode = statusCode };
    }

    private ObjectResult CreateResponse(int statusCode, string? message = null, bool isSuccess = true)
    {
      var response = new Response
      {
        StatusCode = statusCode,
        Path = HttpContext.Request.Path,
        Message = message,
        IsSuccess = isSuccess
      };

      return new ObjectResult(response) { StatusCode = statusCode };
    }

    protected ActionResult OkResponse<T>(T data) => CreateResponse(data, StatusCodes.Status200OK);

    protected ActionResult OkResponse<T>(T data, string message) => CreateResponse(data, StatusCodes.Status200OK, message);

    protected ActionResult OkResponse() => CreateResponse(StatusCodes.Status200OK);

    protected ActionResult OkResponse(string message) => CreateResponse(StatusCodes.Status200OK, message);

    protected ActionResult CreatedResponse<T>(T data) => CreateResponse(data, StatusCodes.Status201Created);

    protected ActionResult CreatedResponse<T>(T data, string message) => CreateResponse(data, StatusCodes.Status201Created, message);

    protected ActionResult CreatedResponse() => CreateResponse(StatusCodes.Status201Created);

    protected ActionResult CreatedResponse(string message) => CreateResponse(StatusCodes.Status201Created, message);

    protected ActionResult NoContentResponse() => CreateResponse(StatusCodes.Status204NoContent);

    protected ActionResult NoContentResponse(string message) => CreateResponse(StatusCodes.Status204NoContent, message);

    protected ActionResult NotFoundResponse() => CreateResponse(StatusCodes.Status404NotFound, isSuccess: false);

    protected ActionResult NotFoundResponse(string message) => CreateResponse(StatusCodes.Status404NotFound, message, isSuccess: false);

    protected ActionResult ConflictResponse() => CreateResponse(StatusCodes.Status409Conflict, isSuccess: false);

    protected ActionResult ConflictResponse(string message) => CreateResponse(StatusCodes.Status409Conflict, message, isSuccess: false);

    protected ActionResult InternalServerErrorResponse() => CreateResponse(StatusCodes.Status500InternalServerError, isSuccess: false);

    protected ActionResult InternalServerErrorResponse(string message) => CreateResponse(StatusCodes.Status500InternalServerError, message, isSuccess: false);

    protected ActionResult ServiceUnavailableResponse() => CreateResponse(StatusCodes.Status503ServiceUnavailable, isSuccess: false);

    protected ActionResult ServiceUnavailableResponse(string message) => CreateResponse(StatusCodes.Status503ServiceUnavailable, message, isSuccess: false);
  }
}
