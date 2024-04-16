
using System;

namespace CachingKitBase
{
    public sealed class NullCacheStrategy : ICacheStrategy 
    {        
        public void Remove(string key)
        {
        }

        public T Retrieve<T>(string key)
        {
            return default(T)!;
        }

        public void Store<T>(string key, T data, TimeSpan? duration = null)
        {
        }
    }
}
