using System;

namespace CachingKitBase
{
    public interface ICacheStrategyAsync
    {
        void RemoveAsync(string key);
        void StoreAsync<T>(string key, T data, TimeSpan? duration = null);
        void StoreAsync<T>(string key, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpireTime = null);
        T RetrieveAsync<T>(string key);
    }
}
