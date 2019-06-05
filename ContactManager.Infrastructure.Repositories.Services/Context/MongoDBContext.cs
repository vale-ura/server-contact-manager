using System;
using ContactManager.Infrastructure.Repositories.Interface.Context;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ContactManager.Infrastructure.Repositories.Services.Context
{
    public class MongoDBContext : IMongoContext
    {
        private readonly IConfiguration _config;

        public MongoClient Client { get; set; }
        public IMongoDatabase DatabaseBase { get; set; }

        public MongoDBContext(IConfiguration configuration)
        {
            _config = configuration;
            Client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            DatabaseBase = Client.GetDatabase("ContactManagerDB");
        }
    }
}
