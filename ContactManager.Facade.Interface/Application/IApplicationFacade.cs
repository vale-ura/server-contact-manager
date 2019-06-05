using System.Collections.Generic;


namespace ContactManager.Facade.Interface.Application
{
    public interface IApplicationFacade
    {
        //     List<Applications> Get();

        //     Applications Get(string id);

        //     void Create(Applications application);

        //     void Update(string id, Applications appIn);

        //     void Remove(string id);

        object Get();

        object Get(string id);

        object GetByName(string name);

        void Create();

        void Update(string id);

        void Remove(string id);
    }
}