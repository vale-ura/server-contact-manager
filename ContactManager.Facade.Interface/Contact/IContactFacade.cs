using System;
using System.Collections.Generic;
using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Domain.DTO.Filters;

namespace ContactManager.Facade.Interface.Contact
{
    public interface IContactFacade
    {
        // List<People> Get();

        // People Get(string id);

        // void Create(People application);

        // void Update(string id, People appIn);

        // void Remove(People appIn);

        void Get();

        void Get(string id);

        IEnumerable<People> Get(FilterDTO filters);

        void Create();

        void Update();

        object Remove(string id);
    }
}
