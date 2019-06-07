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

        public void Create()
        {
            throw new NotImplementedException();
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

        public object Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

    }
}
