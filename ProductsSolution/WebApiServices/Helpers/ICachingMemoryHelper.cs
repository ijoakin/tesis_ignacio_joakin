using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiServices.Helpers
{
    public interface ICachingMemoryHelper
    {
        object GetValue(string key);
        void Add(string key, object value, DateTimeOffset absExpiration);
        void Delete(string key);
    }
}
