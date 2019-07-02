using ContactManager.Infrastructure.Commands.Interface;
using ContactManager.Infrastructure.Commands.Service.Extensions;
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
        private IMongoCollection<People> _mongoCollectionPeople;

        private readonly IMongoContext _context;

        public PeopleService(IMongoContext context)
        {
            _context = context;
            _mongoCollectionPeople = _context.DatabaseBase.GetCollection<People>("People");
        }
        public async Task<IEnumerable<People>> Get()
        {
            var query = from p in _mongoCollectionPeople.AsQueryable()
                        select p;

            var result = new List<People>();
            foreach (var people in query)
            {
                if (people.Applications.Any())
                {
                    foreach (var app in people.Applications)
                    {
                        people.Apps.Add(await _context.DatabaseBase.FetchDBRef<Applications>(app));
                    }
                }
                result.Add(people);
            }

            return result.AsEnumerable();
        }

        public async Task<People> Get(string id)
        {
            return await _mongoCollectionPeople.FindSync(x => x.Name == id && x.Excluded == false).FirstAsync();

        }

        public async Task<IEnumerable<People>> GetByName(string name)
        {
            var query = from p in _mongoCollectionPeople.AsQueryable()
                        where p.Name.Contains(name)
                        select p;

            var result = new List<People>();

            foreach (var people in query)
            {
                if (people.Applications.Any())
                {
                    foreach (var app in people.Applications)
                    {
                        people.Apps.Add(await _context.DatabaseBase.FetchDBRef<Applications>(app));
                    }
                }
                result.Add(people);
            }

            return result.AsEnumerable();
        }

        public void Create(People people, string[] apps)
        {
            people.Applications.Clear();

            foreach (var ap in apps)
                people.Applications.Add(new MongoDBRef("ContactManagerDB", "Applications", new ObjectId(ap)));

            _mongoCollectionPeople.InsertOne(people);
        }

        public void Update(string id, People appIn, string[] applications)
        {
            var people = _mongoCollectionPeople.Find(x => x.Id == id).FirstOrDefault();

            people.Email = appIn.Email;
            people.Name = appIn.Name;
            people.Phone = appIn.Phone;

            people.Applications.Clear();

              foreach (var ap in applications)
                people.Applications.Add(new MongoDBRef("ContactManagerDB", "Applications",  new ObjectId(ap)));

            _mongoCollectionPeople.ReplaceOne(x => x.Id == id, people);
        }

        public void Remove(string id)
        {
            _mongoCollectionPeople.UpdateOne(Builders<People>.Filter.Eq("_id", ObjectId.Parse(id)),
                                        Builders<People>.Update.Set("Excluded", true));

        }
    }
}
