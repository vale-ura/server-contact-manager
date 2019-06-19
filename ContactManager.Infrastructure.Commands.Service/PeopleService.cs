using ContactManager.Infrastructure.Commands.Interface;
using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Domain.DTO.Filters;
using ContactManager.Infrastructure.Repositories.Interface.Context;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.Commands.Service
{
    public class PeopleService : IPeopleService
    {
        private IMongoCollection<People> _mongoCollection;

        private readonly IMongoContext _context;

        public PeopleService(IMongoContext context)
        {
            _context = context;
            _mongoCollection = _context.DatabaseBase.GetCollection<People>("People");
            //List<Applications> list = BsonSerializer.Deserialize<List<Applications>>(_mongoCollection.ToJson());

        }
        public async Task<IEnumerable<People>> Get()
        {
            var data = await _mongoCollection.FindAsync(x =>x.Excluded == false);

            var dataReturned = new List<People>();

            while (await data.MoveNextAsync())
            {
                dataReturned.AddRange(data.Current.AsEnumerable());
            }

            return dataReturned.AsEnumerable();
        }

        public async Task<People> Get(string id)
        {
            //return _mongoCollection.Find<People>(people => people.Id == id).FirstOrDefault();
            return await _mongoCollection.FindSync(x => x.Name == id && x.Excluded == false).FirstAsync();

        }

        public async Task<IEnumerable<People>> GetByName(string name)
        {
            var data = await _mongoCollection.FindAsync(x => x.Name.Contains(name) &&
                                                       x.Excluded == false);

            var dataReturned = new List<People>();

            while (await data.MoveNextAsync())
            {
                dataReturned.AddRange(data.Current.AsEnumerable());
            }

            return dataReturned.AsEnumerable();
        }

        public void Create(People people)
        {
            _mongoCollection.InsertOne(people);

        }

        public void Update(string id, People appIn)
        {
            _mongoCollection.ReplaceOne(people => people.Id == id, appIn);

        }

        public void Remove(string id)
        {
            _mongoCollection.UpdateOne(Builders<People>.Filter.Eq("_id", ObjectId.Parse(id)),
                                        Builders<People>.Update.Set("Excluded", true));

        }

        public IEnumerable<People> Get(FilterDTO filterDTO)
        {
            IQueryable<People> query = _mongoCollection.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterDTO.Name))
            {
                query = query.Where(x => x.Name.Contains(filterDTO.Name));
            }

            _mongoCollection.Find<People>(x => x.Name.Contains(filterDTO.Name));
            throw new System.NotImplementedException();
        }
    }


}
