using Application.DTOs;
using Domain.Contract.Redis;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Application.Services.Redis;
public class DistributedCacheService : ICacheService
{
    private readonly IDatabase _database;
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly ILogger<DistributedCacheService> _logger;

    public DistributedCacheService(IConnectionMultiplexer connectionMultiplexer, ILogger<DistributedCacheService> logger)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _database = _connectionMultiplexer.GetDatabase();
        _logger = logger;
    }

    public async Task RemoveAsync(string key)
    {
        _logger.LogInformation("----- Removing from DistributedCache: '{key}'", key);
        await _database.KeyDeleteAsync(key);
    }

    public async Task SetAsyncAll(CacheDto dto)
    {
        if (dto.Tempo == 0)
        {
            _logger.LogInformation($"----- Added to DistributedCache: '{dto.Key}'", dto.Key);
            await _database.StringSetAsync(dto.Key, JsonConvert.SerializeObject(dto.JsonData));
        }
        else
        {
            _logger.LogInformation($"----- Added to DistributedCache: '{dto.Key}'", dto.Key);
            await _database.StringSetAsync(dto.Key, dto.JsonData, TimeSpan.FromDays(dto.Tempo));
        }
    }

    public async Task<string> StringGetAsync(string key)
    {
        _logger.LogInformation($"----- GetAll to DistributedCache: '{key}'", key);
        return await _database.StringGetAsync(key);
    }

    public async Task<List<string>> StringGetAsync()
    {
        var server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints().First());
        var keys = server.Keys();

        var values = new List<string>();
        foreach (var key in keys)
        {
            var value = await _database.StringGetAsync(key);
            values.Add(value);
        }

        _logger.LogInformation("----- GetAll to DistributedCache: all");
        return values;
    }
}
