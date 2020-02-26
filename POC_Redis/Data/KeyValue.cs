using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POC_Redis.Data
{
    [BsonIgnoreExtraElements]
    [Table("KeyValue")]
    public class KeyValue
    {
        [Key]
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
