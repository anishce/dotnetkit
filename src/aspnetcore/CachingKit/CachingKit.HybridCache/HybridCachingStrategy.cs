// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using CachingKitBase;

namespace CachingKit.HybridCaching
{
    public class HybridCachingStrategy : ICacheStrategy
    {
        public HybridCachingStrategy()
        {
            
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
            throw new NotImplementedException();
        }
    }
}
