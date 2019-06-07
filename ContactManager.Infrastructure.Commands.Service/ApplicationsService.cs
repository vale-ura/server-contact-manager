using System.Collections.Generic;
using ContactManager.Infrastructure.Commands.Interface;
using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Repositories.Interface.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Applications>> Get()
        {
            return await _mongoCollection.FindSync(x => x.Excluded == false).ToListAsync();
        }

        public async Task<Applications> Get(string id)
        {
            return await _mongoCollection.FindSync(x => x.Name == id && x.Excluded == false).FirstAsync();
        }

        public async Task<IEnumerable<Applications>> GetByName(string name)
        {
            var data = await _mongoCollection.FindAsync(x => x.Name.Contains(name) && 
                                                        x.Excluded == false);

            

            var dataReturned = new List<Applications>();

            while (await data.MoveNextAsync())
            {
                dataReturned.AddRange(data.Current.AsEnumerable());
            }

            return dataReturned.AsEnumerable();
        }

        private async Task<List<Applications>> Teste()
        {
            return await Task.Run<List<Applications>>(() =>
            {
                List<Applications> lista = new List<Applications>();
                lista.Add(new Applications { Name = "Teste", Description = "Teste Des", Id = "1", Excluded = false });
                return lista;
            });
        }
        public void Create(Applications application)
        {
            _mongoCollection.InsertOne(application);
        }

        public void Update(string id, Applications appIn)
        {
            _mongoCollection.ReplaceOne(application => application.Id == id, appIn);
        }

        public void Remove(string id)
        {
            _mongoCollection.FindOneAndUpdate(app => app.Id == id, new BsonDocument("Deleted", true));
        }
    }
}
