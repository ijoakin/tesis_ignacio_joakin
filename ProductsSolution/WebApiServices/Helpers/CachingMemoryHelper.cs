using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;

namespace WebApiServices.Helpers
{
    public class CachingMemoryHelper : ICachingMemoryHelper
    {
        private IMemoryCache memoryCache;

        public CachingMemoryHelper(IMemoryCache _memoryCache)
        {
            memoryCache = _memoryCache;
        }

        public object GetValue(string key)
        {
            object returnObject;
            memoryCache.TryGetValue(key, out returnObject);

            return returnObject;
        }

        public void Add(string key, object value, DateTimeOffset absExpiration)
        {
            /*var entry = memoryCache.CreateEntry(key);
            entry.Value = value;
            entry.AbsoluteExpiration = absExpiration;*/

            memoryCache.Set(key, value);
        }

        public void Delete(string key)
        {
            memoryCache.Remove(key);
        }
    }
}
