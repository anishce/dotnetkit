using CachingKitBase;
using Enyim.Caching;
using System;

namespace CachingKit.MemCached
{
    public class MemCachedCacheStrategy : ICacheStrategy
    {
        private readonly IMemcachedClient _memcachedClient = null!;

        public MemCachedCacheStrategy(IMemcachedClient memcachedClient)
        {
            this._memcachedClient = memcachedClient;
        }

        public void Remove(string key)
        {
           _memcachedClient.Remove(key);
        }

        public T Retrieve<T>(string key)
        {
           return _memcachedClient.Get<T>(key);
        }

        public void Store<T>(string key, T data, TimeSpan? duration = null)
        {
            if(duration !=null)
            {
                _memcachedClient.Set(key, data, duration.Value);
            }
            else
            {
                //Store for an hour
                _memcachedClient.Set(key, data, 60 * 60);
            }
        }
    }
}
