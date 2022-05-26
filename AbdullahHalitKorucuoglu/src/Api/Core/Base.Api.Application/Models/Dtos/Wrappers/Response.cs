using Newtonsoft.Json;

namespace Base.Api.Application.Models.Dtos;

public class Response<T>
{
    public T Value { get; set; }

    [JsonIgnore]
    public int StatusCode { get; set; }

    [JsonIgnore]
    public bool IsSuccessful { get; set; }

    public string Message { get; set; }

    // Static Factory Method
    public static Response<T> Success(int statusCode = 0)
    {
        return new Response<T> { Value = default, StatusCode = statusCode, IsSuccessful = true };
    }

    public static Response<T> Success(T data, int statusCode = 0)
    {
        return new Response<T> { Value = data, StatusCode = statusCode, IsSuccessful = true };
    }

    public static Response<T> Success(string message, int statusCode = 0)
    {
        return new Response<T> { Value = default, StatusCode = statusCode, IsSuccessful = true, Message = message };
    }

    public static Response<T> Fail(string message, int statusCode = 0)

    {
        return new Response<T>
        {
            Message = message,
            StatusCode = statusCode,
            IsSuccessful = false
        };
    }

    public static Response<T> Fail(T value, int statusCode = 0)
    {
        return new Response<T>
        {
            Value = value,
            StatusCode = statusCode,
            IsSuccessful = false
        };
    }
}

public class NoContent
{
}