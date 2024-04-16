using System;

namespace CachingKitBase
{
    public interface ICacheStrategy
    {
        void Remove(string key);
        void Store<T>(string key, T data, TimeSpan? duration = null);
        T Retrieve<T>(string key);
    }
}
