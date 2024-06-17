using DatingApp.Application.Common.Enums;

namespace DatingApp.Application.Common.Interfaces;

public interface IResult
{
  public ResultStatus Status { get; }
  public bool IsSuccess { get; }
  public string Message { get; }
}
