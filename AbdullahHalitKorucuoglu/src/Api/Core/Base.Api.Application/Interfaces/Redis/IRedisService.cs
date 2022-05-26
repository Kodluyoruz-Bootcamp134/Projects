using System.Threading.Tasks;

namespace Base.Api.Application.Interfaces;

public interface IRedisService
{
    Task<T> GetAsync<T>(string key);

    Task SetAsync(string key, object data);

    Task<bool> IsKeyAsync(string key);

    Task RemoveAsync(string key);
}