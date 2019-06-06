using System;
using System.Collections.Generic;
using ContactManager.Facade.Interface.Application;
using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Commands.Interface;
using System.Threading.Tasks;

namespace ContactManager.Facade.Service.Application
{
    public class ApplicationFacade : IApplicationFacade
    {
        private readonly IApplicationsService _applicationService;

        public ApplicationFacade(IApplicationsService applicationService)
        {
            _applicationService = applicationService;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Applications>> Get()
        {
            return await _applicationService.Get();
        }

        public async Task<Applications> Get(string id)
        {
            return await _applicationService.Get(id);
        }

        public async Task<IEnumerable<Applications>> GetByName(string name)
        {
            return await _applicationService.GetByName(name);
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(string id)
        {
            throw new NotImplementedException();
        }
    }
}
