using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManager.Facade.Interface.Contact;
using ContactManager.Infrastructure.Commands.Interface;
using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Domain.DTO.Filters;

namespace ContactManager.Facade.Service.Contact
{
    public class ContactFacade : IContactFacade
    {
        private readonly IPeopleService _peopleService;
        public ContactFacade(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public void Create(People people, string[] apps)
        {
            _peopleService.Create(people, apps);
        }
        public async Task<IEnumerable<People>> Get()
        {
            return await _peopleService.Get();
        }

        public async Task<People> Get(string id)
        {
            return await _peopleService.Get(id);
        }

        public async Task<IEnumerable<People>> GetByName(string name)
        {
            return await _peopleService.GetByName(name);
        }

        public void Remove(string id)
        {
           _peopleService.Remove(id);
        }

        public void Update(string id, People people)
        {
            _peopleService.Update(id, people);
        }

    }
}
