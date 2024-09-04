using CachingKitBase;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            var jsonData = cache.GetStringAsync(key);

            if (jsonData is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);
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
