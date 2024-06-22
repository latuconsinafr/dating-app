namespace DatingApp.Web.Common.Models;

public class Response<T>
{
  public int StatusCode { get; set; } = StatusCodes.Status200OK;
  public DateTime Timestamp { get; set; } = DateTime.UtcNow;
  public string Path { get; set; } = string.Empty;
  public bool IsSuccess { get; set; } = true;
  public string? Message { get; set; } = null;
  public T? Data { get; set; }
  public string? Error { get; set; } = null;
}

public class Response : Response<object>
{
}

