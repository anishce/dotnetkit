using CachingKitBase;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace CachingKit.InMemory
{
    public class InMemoryCacheStrategy : ICacheStrategy
    {
        private readonly IMemoryCache _memoryCache = null!;

        public InMemoryCacheStrategy(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public T Retrieve<T>(string key)
        {
            if (_memoryCache != null)
            {
                return _memoryCache.Get<T>(key);
            }
            return default(T);
        }

        public void Store<T>(string key, T data, TimeSpan? duration = null)
        {
            _memoryCache.Set(key, data);
        }
    }
}
