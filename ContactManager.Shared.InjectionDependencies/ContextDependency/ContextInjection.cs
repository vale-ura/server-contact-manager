using System;
using ContactManager.Infrastructure.Repositories.Interface.Context;
using ContactManager.Infrastructure.Repositories.Services.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.Shared.InjectionDependencies.ContextDependency
{
    public class ContextInjection
    {
        public static void RegisterService(IServiceCollection register)
        {
            register.AddScoped<IMongoContext, MongoDBContext>();
        }
    }
}
