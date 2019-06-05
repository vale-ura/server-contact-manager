using System.Collections.Generic;
using ContactManager.Infrastructure.Commands.Interface;
using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Repositories.Interface.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ContactManager.Infrastructure.Commands.Service
{
    public class ApplicationsService : IApplicationsService
    {
        private IMongoCollection<Applications> _mongoCollection;

        private readonly IMongoContext _context;

        public ApplicationsService(IMongoContext context)
        {
            _context = context;

            _mongoCollection = _context.DatabaseBase.GetCollection<Applications>("Applications");
        }

        public List<Applications> Get()
        {
            return _mongoCollection.Find(applications => true).ToList();
        }
        
        public Applications Get(string id)
        {
            return _mongoCollection.Find<Applications>(applications => applications.Id == id).FirstOrDefault();
        }
        public void Create(Applications application)
        {
            _mongoCollection.InsertOne(application);
        }

        public void Update(string id, Applications appIn)
        {
            _mongoCollection.ReplaceOne(application => application.Id == id, appIn);
        }

        //public void Remove(Applications appIn)
        //{
        //    _mongoCollection.DeleteOne(application => application.Id == appIn.Id);

        //}

        public void Remove(string id)
        {
            _mongoCollection.FindOneAndUpdate(app => app.Id == id, new BsonDocument("Deleted", true));
        }

    }
}
