using ContactManager.Infrastructure.Domain.Data;
using System;
using System.Collections.Generic;

namespace ContactManager.Infrastructure.Commands.Interface
{
    public interface IApplicationsService
    {
        List<Applications> Get();
        Applications Get(string id);
        void Create(Applications application);
        void Update(string id, Applications appIn);
        //void Remove(Applications appIn);
        void Remove(string id);

    }
}
