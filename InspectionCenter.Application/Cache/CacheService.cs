using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InspectionCenter.Application.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string cacheKey)
        {
            var data = await _cache.GetAsync(cacheKey);
            if (data == null)
                return default(T?);

            return JsonSerializer.Deserialize<T>(data);
        }

        public async Task SetAsync<T>(string cacheKey ,T value ,TimeSpan expiry)
        {
           var json = JsonSerializer.Serialize(value);

           await _cache.SetStringAsync(cacheKey, json ,new DistributedCacheEntryOptions()
           {
               AbsoluteExpirationRelativeToNow = expiry
           }); 
        }
    }
}
