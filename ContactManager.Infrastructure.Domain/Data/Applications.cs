using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContactManager.Infrastructure.Domain.Data
{
    public class Applications : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Excluded { get; set; }
    }
}

