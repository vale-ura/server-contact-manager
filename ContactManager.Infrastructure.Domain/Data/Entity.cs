using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ContactManager.Infrastructure.Domain.Data
{
    [BsonSerializer]
    [BsonIgnoreExtraElements(true)]
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}