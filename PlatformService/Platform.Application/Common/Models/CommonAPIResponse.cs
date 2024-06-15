namespace Platform.Application.Common.Models;
public record CommonAPIResponse(string message, object data);
public record CommonAPIResponse<T>(string message, T data);

