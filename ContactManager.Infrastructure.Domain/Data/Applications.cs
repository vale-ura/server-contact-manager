using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContactManager.Infrastructure.Domain.Data
{
    public class Applications
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Excluded")]
        public bool Excluded { get; set; }
    }
}

