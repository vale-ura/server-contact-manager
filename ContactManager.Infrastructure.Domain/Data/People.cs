using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Infrastructure.Domain.Data
{
    public class People
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [BsonRequired()]
        public string Name { get; set; }

        [BsonElement("Email")]
        [BsonRequired()]
        public string Email { get; set; }

        [BsonElement("Phone")]
        [BsonRequired()]
        public string Phone { get; set; }

        //[BsonElement("Applications")]
        //[BsonRequired()]
        //public Applications Applications { get; set; }

        [BsonElement("Excluded")]
        [BsonRequired()]
        public bool Excluded { get; set; }
    }
}

