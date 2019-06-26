using System.Collections.Generic;
using System.Xml.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ContactManager.Infrastructure.Domain.Data
{
    public class People : Entity
    {
        public People()
        {
            Apps = new List<Applications>();
        }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public IList<MongoDBRef> Applications { get; set; }

        public IList<Applications> Apps { get; set; }

        public bool Excluded { get; set; }
    }
}

