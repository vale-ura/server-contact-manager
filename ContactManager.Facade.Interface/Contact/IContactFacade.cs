using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Domain.DTO.Filters;

namespace ContactManager.Facade.Interface.Contact
{
    public interface IContactFacade
    {
        Task<IEnumerable<People>> Get();

        Task<People> Get(string id);

        Task<IEnumerable<People>> GetByName(string name);

        void Create(People people, string[] apps);

        void Update(string id, People app);

        void Remove(string id);
    }
}
