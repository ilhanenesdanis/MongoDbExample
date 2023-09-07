using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbExample.Models
{
    public class Course:BaseEntity
    {
     
        public string Name { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }

        public Feature Feature { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
