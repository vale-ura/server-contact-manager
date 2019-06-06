using System;
using System.Collections.Generic;
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

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<People> Get(FilterDTO filters)
        {
            throw new NotImplementedException();
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
