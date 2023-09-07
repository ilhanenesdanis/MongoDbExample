using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Models
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
    }
}
