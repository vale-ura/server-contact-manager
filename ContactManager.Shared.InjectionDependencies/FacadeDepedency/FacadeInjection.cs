using System;
using ContactManager.Facade.Interface.Application;
using ContactManager.Facade.Interface.Contact;
using ContactManager.Facade.Service.Application;
using ContactManager.Facade.Service.Contact;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.Shared.InjectionDependencies.FacadeDepedency
{
    public class FacadeInjection
    {
        public static void RegisterService(IServiceCollection register)
        {
            register.AddTransient<IApplicationFacade, ApplicationFacade>();
            register.AddTransient<IContactFacade, ContactFacade>(); 
        }
    }
}
