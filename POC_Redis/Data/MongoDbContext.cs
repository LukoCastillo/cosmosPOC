using MongoDB.Driver;
using POC_Redis.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_Redis.Data
{
    public class MongoDbContext
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;

        public MongoDbContext(IMongoClient client, IMongoDatabase database)
        {
            this.client = client;
            this.database = database;
        }

        public IMongoCollection<Operation> Operations
        {
            get { return database.GetCollection<Operation>("operation"); }
        }

        public IMongoCollection<KeyValue> KeyValues
        {
            get { return database.GetCollection<KeyValue>("KeyValue"); }
        }
    }
}
