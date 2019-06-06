using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Domain.DTO.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Infrastructure.Commands.Interface
{
    public interface IPeopleService
    {
        List<People> Get();
        People Get(string id);
        IEnumerable<People> Get(FilterDTO filterDTO);
        void Create(People application);
        void Update(string id, People appIn);
        //void Remove(People appIn);
        void Remove(string id);
    }
}
