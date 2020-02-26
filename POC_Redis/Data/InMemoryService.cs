using Microsoft.Extensions.Caching.Memory;
using POC_Redis.Data.Abstraction;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace POC_Redis.Data
{
    public class InMemoryService : ICacheProvider
    {
        private readonly IMemoryCache _cache;

        public InMemoryService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SaveData(string data)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(10));
            _cache.Set("key1", data, cacheEntryOptions);
        }

        public Task<CacheData> GetValue()
        {
            var stopwatch = Stopwatch.StartNew();
            _cache.TryGetValue("key1", out string value);
            stopwatch.Stop();
            var result = new CacheData()
            {
                key = "key1",
                value = value,
                time = stopwatch.Elapsed.ToString()
            };
            return Task.FromResult(result);
        }

       
    }
}
