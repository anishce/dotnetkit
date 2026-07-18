// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using CachingKitBase;
using Microsoft.Extensions.Caching.Hybrid;

namespace CachingKit.HybridCaching
{
    public class HybridCachingStrategy(HybridCache hybridCache) : ICacheStrategy
    {
        private readonly HybridCache hybridCache = hybridCache;

        public void Remove(string key)
        {
            this.hybridCache.RemoveAsync(key).GetAwaiter().GetResult();
        }

        public T Retrieve<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Store<T>(string key, T data, TimeSpan? duration = null)
        {
            var options = new HybridCacheEntryOptions
            {
                Expiration = duration ?? TimeSpan.FromHours(1),
                LocalCacheExpiration = TimeSpan.FromMinutes(30)
            };

            this.hybridCache.SetAsync(key, data, options).GetAwaiter().GetResult();
        }

        public void Store<T>(string key, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpireTime = null)
        {
            var options = new HybridCacheEntryOptions
            {
                Expiration = absoluteExpireTime ?? TimeSpan.FromHours(1),
                LocalCacheExpiration = slidingExpireTime ?? TimeSpan.FromMinutes(30)
            };

            this.hybridCache.SetAsync(key, data, options).GetAwaiter().GetResult();
        }
    }
}
