using CachingKitBase;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CachingKit.Redis
{
    internal class RedisCacheStrategy : ICacheStrategy
    {
        private readonly IDistributedCache cache;

        public RedisCacheStrategy(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public T Retrieve<T>(string key)
        {
            // Synchronously wait for the cached string (keep method signature unchanged).
            var jsonData = cache.GetStringAsync(key).GetAwaiter().GetResult();

            if (string.IsNullOrEmpty(jsonData))
            {
                return default!;
            }

            var deserialized = JsonSerializer.Deserialize<T>(jsonData);

            // If deserialization returns null, return default. Use null-forgiving to silence CS8603.
            return deserialized is null ? default! : deserialized;
        }

        public void Store<T>(string key, T data, TimeSpan? duration = null)
        {
            var jsonData = JsonSerializer.Serialize(data);

            cache.SetString(key, jsonData);
        }

        public void Store<T>(string key, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = slidingExpireTime;

            var jsonData = JsonSerializer.Serialize(data);

            cache.SetString(key, jsonData, options);
        }
    }
}
