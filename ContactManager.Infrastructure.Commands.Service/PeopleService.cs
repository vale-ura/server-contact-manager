using ContactManager.Infrastructure.Commands.Interface;
using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Domain.DTO.Filters;
using ContactManager.Infrastructure.Repositories.Interface.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

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
        }
        public List<People> Get()
        {
            return _mongoCollection.Find(people => true).ToList();
        }

        public People Get(string id)
        {
            return _mongoCollection.Find<People>(people => people.Id == id).FirstOrDefault();

        }

        public void Create(People people)
        {
            _mongoCollection.InsertOne(people);

        }

        public void Update(string id, People appIn)
        {
            _mongoCollection.ReplaceOne(people => people.Id == id, appIn);

        }

        //public void Remove(People appIn)
        //{
        //    _mongoCollection.DeleteOne(people => people.Id == appIn.Id);

        //}

        public void Remove(string id)
        {
            _mongoCollection.DeleteOne(people => people.Id == id);

        }

        public IEnumerable<People> Get(FilterDTO filterDTO)
        {
            IQueryable<People> query = _mongoCollection.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterDTO.Name)) //Remove IF
            {
                query = query.Where(x => x.Name.Contains(filterDTO.Name));
            }

            _mongoCollection.Find<People>(x => x.Name.Contains(filterDTO.Name));
            throw new System.NotImplementedException();
        }
    }


}
