using DatingApp.Application.Common.Interfaces;

namespace DatingApp.Application.Common.Models;

public class Result(bool isSuccess, string? message) : IResult
{
  private readonly string? _message = message;

  private static string GetDefaultMessage(bool isSuccess)
  {
    return isSuccess ? "Operation successful." : "Operation failed.";
  }

  public bool IsSuccess { get; } = isSuccess;
  public string Message => string.IsNullOrEmpty(_message) ? GetDefaultMessage(IsSuccess) : _message;

  public static Result Success(string? message = null) => new(true, message);
  public static Result<T> Success<T>(T value, string? message = null) => new(true, value, message);

  public static Result Failure(string? message = null) => new(false, message);
  public static Result<T> Failure<T>(string? message = null) => new(false, default, message);
}

public class Result<T> : Result
{
  internal Result(bool isSuccess, T? value, string? message) : base(isSuccess, message)
  {
    Value = value;
  }

  public T? Value { get; }
}
