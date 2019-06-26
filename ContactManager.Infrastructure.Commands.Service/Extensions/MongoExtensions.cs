using System.Threading.Tasks;
using ContactManager.Infrastructure.Domain.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ContactManager.Infrastructure.Commands.Service.Extensions
{
    public static class MongoExtensions
    {
        public static async Task<T> FetchDBRef<T>(this IMongoDatabase database, MongoDBRef reference) where T : Entity
        {
            var filter = Builders<T>.Filter.Eq(e => (BsonObjectId)e.Id, (BsonObjectId)reference.Id);
            return await database.GetCollection<T>(reference.CollectionName).Find(filter).FirstOrDefaultAsync();
        }
    }
}