using Application.DTOs;

namespace Domain.Contract.Redis;

public interface ICacheService
{
    Task SetAsyncAll(CacheDto dto);
    Task<string> StringGetAsync(string key);
    Task<List<string>> StringGetAsync();
    Task RemoveAsync(string key);
}
