using DatingApp.Application.Common.Enums;
using DatingApp.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Web.Common.Models;

public class Response<T>
{
  public int StatusCode { get; set; } = StatusCodes.Status200OK;
  public DateTime Timestamp { get; set; } = DateTime.UtcNow;
  public string Path { get; set; } = string.Empty;
  public bool IsSuccess { get; set; } = true;
  public string Message { get; set; } = string.Empty;
  public T? Data { get; set; }
  public string? Error { get; set; } = string.Empty;
}

public static class ResponseWrapper
{
  private static readonly Dictionary<ResultStatus, int> statusCodes = new()
  {
    {ResultStatus.Ok, 200},
    {ResultStatus.Created, 201},
    {ResultStatus.NoContent, 204},
    {ResultStatus.Unauthorized, 401},
    {ResultStatus.Forbidden, 403},
    {ResultStatus.NotFound, 404},
    {ResultStatus.Conflict, 409},
    {ResultStatus.Error, 500},
    {ResultStatus.Unavailable, 503},
  };

  public static ActionResult Return(HttpContext httpContext, Result result)
  {
    return Return(httpContext, result, null);
  }

  public static ActionResult Return(HttpContext httpContext, Result result, string? message = null)
  {
    var response = new Response<object>
    {
      StatusCode = statusCodes.TryGetValue(result.Status, out int statusCode) ? statusCode : 500,
      Timestamp = DateTime.UtcNow,
      Path = httpContext.Request.Path,
      IsSuccess = result.IsSuccess,
      Message = message ?? result.Message,
      Error = result.IsSuccess ? default : result.Status.ToString(),
    };

    return new ObjectResult(response)
    {
      StatusCode = statusCodes.TryGetValue(result.Status, out statusCode) ? statusCode : 500,
    };
  }

  public static ActionResult<T> Return<T>(HttpContext httpContext, Result<T> result)
  {
    return Return(httpContext, result, null);
  }

  public static ActionResult<T> Return<T>(HttpContext httpContext, Result<T> result, string? message = null)
  {
    var response = new Response<T>
    {
      StatusCode = statusCodes.TryGetValue(result.Status, out int statusCode) ? statusCode : 500,
      Timestamp = DateTime.UtcNow,
      Path = httpContext.Request.Path,
      IsSuccess = result.IsSuccess,
      Message = message ?? result.Message,
      Data = result.IsSuccess ? result.Value : default,
      Error = result.IsSuccess ? default : result.Status.ToString(),
    };

    return new ObjectResult(response)
    {
      StatusCode = statusCodes.TryGetValue(result.Status, out statusCode) ? statusCode : 500,
    };
  }

  public static ActionResult Error(HttpContext httpContext)
  {
    return Error(httpContext, null);
  }

  public static ActionResult Error(HttpContext httpContext, string? message = null)
  {
    var result = new Result(ResultStatus.Error, message);

    return Return(httpContext, result, message);
  }
}
