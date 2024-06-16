using DatingApp.Application.Common.Enums;
using DatingApp.Application.Common.Interfaces;

namespace DatingApp.Application.Common.Models;

public class Result(ErrorCode error, string message) : IResult
{
  public ErrorCode Error { get; } = error;
  public bool IsSuccess => Error == ErrorCode.None;
  public string Message { get; } = message;

  public static Result Success() => new(ErrorCode.None, string.Empty);
  public static Result Success(string message) => new(ErrorCode.None, message);
  public static Result<T> Success<T>() => new(ErrorCode.None, string.Empty, default);
  public static Result<T> Success<T>(T value) => new(ErrorCode.None, string.Empty, value);
  public static Result<T> Success<T>(T value, string message) => new(ErrorCode.None, message, value);

  public static Result Failure(ErrorCode error) => new(error, string.Empty);
  public static Result Failure(ErrorCode error, string message) => new(error, message);
  public static Result<T> Failure<T>(ErrorCode error) => new(error, string.Empty, default);
  public static Result<T> Failure<T>(ErrorCode error, string message) => new(error, message, default);
}

public class Result<T>(ErrorCode error, string message, T? value) : Result(error, message)
{
  public T? Value { get; } = value;
}
