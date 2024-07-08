using Bookify.Application.Abstractions.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Bookify.Infrastructure.Caching;
internal sealed class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        byte[]? bytes = await _cache.GetAsync(key, cancellationToken);

        return bytes is null ? default : Deserialize<T>(bytes);
    }

    public Task SetAsync<T>(
        string key,
        T value,
        TimeSpan? expiration = null,
        CancellationToken cancellationToken = default)
    {
        byte[] bytes = Serialize(value);

        return _cache.SetAsync(key, bytes, CacheOptions.Create(expiration), cancellationToken);
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default) =>
        _cache.RemoveAsync(key, cancellationToken);

    private static T Deserialize<T>(byte[] bytes)
    {
        string jsonString = Encoding.UTF8.GetString(bytes);
        return JsonSerializer.Deserialize<T>(jsonString)!;
    }

    private static byte[] Serialize<T>(T value)
    {
        using var memoryStream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(memoryStream))
        {
            JsonSerializer.Serialize(writer, value);
        }
        return memoryStream.ToArray();
    }
}
