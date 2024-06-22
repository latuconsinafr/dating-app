namespace DatingApp.Application.Common.Interfaces;

public interface IResult
{
  public bool IsSuccess { get; }
  public string Message { get; }
}
