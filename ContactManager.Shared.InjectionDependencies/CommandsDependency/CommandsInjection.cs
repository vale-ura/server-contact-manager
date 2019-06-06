using System;
using ContactManager.Infrastructure.Commands.Interface;
using ContactManager.Infrastructure.Commands.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.Shared.InjectionDependencies.CommandsDependency
{
    public class CommandsInjection
    {
        public static void RegisterService(IServiceCollection register)
        {
            register.AddTransient<IApplicationsService, ApplicationsService>();
            register.AddTransient<IPeopleService, PeopleService>();
        }
    }
}
