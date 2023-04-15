
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace BankingService.Extensions;
public static class DistributedCacheExtensions
{
    public static async Task<T> GetDataAsync<T>(this IDistributedCache cache, string cacheKey)
    {
        var data = await cache.GetStringAsync(cacheKey);
        if (data != null)
        {
            var cachedData = JsonConvert.DeserializeObject<T>(data);
            return cachedData;
        }

        return default(T);
    }

    public static async Task SetDataAsync<T>(this IDistributedCache cache, string cacheKey, T value, TimeSpan? slidingExpiration = null, TimeSpan? absoluteExpiration = null)
    {
      
        var data = JsonConvert.SerializeObject(value);

        var options = new DistributedCacheEntryOptions();

        if (slidingExpiration.HasValue)
        {
            options.SetSlidingExpiration(slidingExpiration.Value);
        }

        if (absoluteExpiration.HasValue)
        {
            options.SetAbsoluteExpiration(absoluteExpiration.Value);
        }
        await cache.SetStringAsync(cacheKey, data, options);
    }
}