using ContactManager.Infrastructure.Domain.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.Commands.Interface
{
    public interface IApplicationsService
    {
        Task<IEnumerable<Applications>> Get();
        Task<Applications> Get(string id);
        Task<IEnumerable<Applications>> GetByName(string name);
        void Create(Applications application);
        void Update(string id, Applications appIn);
        void Remove(string id);

    }
}
