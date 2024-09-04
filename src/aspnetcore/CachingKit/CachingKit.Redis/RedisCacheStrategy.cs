﻿using CachingKitBase;
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
            throw new NotImplementedException();
        }

        public T Retrieve<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Store<T>(string key, T data, TimeSpan? duration = null)
        {
            throw new NotImplementedException();
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
