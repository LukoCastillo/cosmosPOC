using System;
using System.Diagnostics;
using System.Threading.Tasks;
using POC_Redis.Data.Abstraction;
using StackExchange.Redis;

namespace POC_Redis.Data
{
    public class RedisService : ICacheProvider
    {
 
        private readonly IConnectionMultiplexer _connection;

        public RedisService(IConnectionMultiplexer connection)
        {
            _connection = connection;
        }

        public void SaveData(string data)
        {
            IDatabase cache = _connection.GetDatabase();
            cache.StringSetAsync("key1", data);

        }

        public Task<CacheData> GetValue()
        {
            var stopwatch = Stopwatch.StartNew();

            IDatabase cache = _connection.GetDatabase();
            var value = cache.StringGet("key1");
            stopwatch.Stop();

            var result = new CacheData() { 
                key = "key1", 
                value = value, 
                time = stopwatch.Elapsed.ToString()
            };
            return Task.FromResult(result);

        }


    }
}
