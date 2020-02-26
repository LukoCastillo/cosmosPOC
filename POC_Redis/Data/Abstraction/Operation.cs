using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace POC_Redis.Data.Abstraction
{
    [BsonIgnoreExtraElements]
    public class Operation
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string OperationId { get; set; }

        public string FileName { get; set; }

        public string Provider { get; set; }

        public dynamic Data { get; set; }
    }
}
