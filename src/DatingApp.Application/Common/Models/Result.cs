using DatingApp.Application.Common.Enums;
using DatingApp.Application.Common.Interfaces;

namespace DatingApp.Application.Common.Models;

public class Result(ResultStatus status, string? message) : IResult
{
  private static readonly Dictionary<ResultStatus, string> messages = new()
  {
    {ResultStatus.Ok, "OK"},
    {ResultStatus.Created, "Created"},
    {ResultStatus.NoContent, "No Content"},
    {ResultStatus.Unauthorized, "Unauthorized"},
    {ResultStatus.Forbidden, "Forbidden"},
    {ResultStatus.NotFound, "Not found"},
    {ResultStatus.Conflict, "Conflict"},
    {ResultStatus.Error, "Error"},
    {ResultStatus.Unavailable, "Unavailable"},
  };

  private readonly string? _message = message;

  public ResultStatus Status { get; } = status;
  public bool IsSuccess => Status is ResultStatus.Ok or ResultStatus.Created or ResultStatus.NoContent;
  public string Message => !string.IsNullOrEmpty(_message) ? _message : messages.TryGetValue(Status, out string? message) ? message : "Error";

  public static Result Success(ResultStatus status = ResultStatus.Ok, string? message = null) => new(status, message);
  public static Result<T> Success<T>(T value, ResultStatus status = ResultStatus.Ok, string? message = null) => new(status, value, message);

  public static Result Failure(ResultStatus status = ResultStatus.Error, string? message = null) => new(status, message);
  public static Result<T> Failure<T>(ResultStatus status = ResultStatus.Error, string? message = null) => new(status, default, message);
}

public class Result<T> : Result
{
  internal Result(ResultStatus status, T? value, string? message) : base(status, message)
  {
    Value = value;
  }

  public T? Value { get; }
}
