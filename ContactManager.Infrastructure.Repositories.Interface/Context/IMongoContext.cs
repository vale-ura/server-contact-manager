using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;

namespace ContactManager.Infrastructure.Repositories.Interface.Context
{
    public interface IMongoContext
    {
        MongoClient Client { get; set; }

        IMongoDatabase DatabaseBase { get; set; }
    }
}
