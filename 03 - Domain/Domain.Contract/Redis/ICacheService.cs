namespace Domain.Contract.Redis;

public interface ICacheService
{
    Task SetAsyncAll(string key, string jsonData, TimeSpan tempo);
    Task SetAsyncAll(string key, string jsonData);
    Task<string> StringGetAsync(string key);
    Task<List<string>> StringGetAsync();
    Task RemoveAsync(string key);
}
