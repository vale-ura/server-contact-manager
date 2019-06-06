using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManager.Infrastructure.Domain.Data;

namespace ContactManager.Facade.Interface.Application
{
    public interface IApplicationFacade
    {
        Task<IEnumerable<Applications>> Get();

        Task<Applications> Get(string id);

        Task<IEnumerable<Applications>> GetByName(string name);

        void Create();

        void Update(string id);

        void Remove(string id);
    }
}