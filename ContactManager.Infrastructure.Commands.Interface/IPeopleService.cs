using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Domain.DTO.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.Commands.Interface
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> Get();
        Task<People> Get(string id);
        Task<IEnumerable<People>> GetByName(string name);
        void Create(People application);
        void Update(string id, People appIn);
        void Remove(string id);
    }
}
