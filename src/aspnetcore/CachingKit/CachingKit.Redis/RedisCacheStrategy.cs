using CachingKitBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingKit.Redis
{
    internal class RedisCacheStrategy : ICacheStrategy
    {
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
    }
}
