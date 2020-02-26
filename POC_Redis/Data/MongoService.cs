using MongoDB.Bson;
using MongoDB.Driver;
using POC_Redis.Data.Abstraction;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace POC_Redis.Data
{
    public class MongoService : ICacheProvider
    {
        private readonly MongoDbContext dbContext;
        public MongoService(MongoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<CacheData> GetValue()
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                FilterDefinition<KeyValue> filter = Builders<KeyValue>.Filter.Eq(m => m.Key, "key1");
                var resultObj = dbContext.KeyValues.Find(filter).FirstOrDefault();
                var rr = dbContext.Operations.Find(new BsonDocument()).FirstOrDefault();
                var result = new CacheData()
                {
                    key = "key1",
                    value = resultObj.Value,
                    time = stopwatch.Elapsed.ToString()
                };
                return Task.FromResult(result);
            }catch(Exception ex)
            {
                
                throw ex;
            }
        }

        public void SaveData(string data)
        {
            try
            {
                var value = new KeyValue { Key = "key1", Value = data };
                dbContext.KeyValues.InsertOne(value);
            }catch(Exception ex)
            {                throw ex;
            }
        
        }
    }
}
