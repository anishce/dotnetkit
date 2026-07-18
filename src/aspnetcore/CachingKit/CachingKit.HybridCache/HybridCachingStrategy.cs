// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using CachingKitBase;
using Microsoft.Extensions.Caching.Hybrid;
using System.Xml.Linq;

namespace CachingKit.HybridCaching
{
    public class HybridCachingStrategy : ICacheStrategy
    {
        private readonly HybridCache hybridCache;
        public HybridCachingStrategy(HybridCache hybridCache)
        {
            this.hybridCache = hybridCache;
        }

        public void Remove(string key)
        {
            this.hybridCache.RemoveAsync(key).ConfigureAwait(true);
        }

        public T Retrieve<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Store<T>(string key, T data, TimeSpan? duration = null)
        {
            this.hybridCache.SetAsync(key, data).ConfigureAwait(true);
        }

        public void Store<T>(string key, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpireTime = null)
        {
            var options = new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromHours(1),
                LocalCacheExpiration = TimeSpan.FromMinutes(30)
            };

            this.hybridCache.SetAsync(key, data).ConfigureAwait(true);
        }
    }
}
