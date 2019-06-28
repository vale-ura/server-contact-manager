using ContactManager.Infrastructure.Domain.DTO.Contact;
using ContactManager.Infrastructure.Domain.DTO.Filters;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Facade.Interface.Contact;
using ContactManager.API.Helpers;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using ContactManager.Infrastructure.Domain.Data;

namespace ContactManager.API.Controllers.Contacts
{
    [Route("v1/contact")]
    public class ContactController : Controller
    {
        private readonly IContactFacade _contactFacade;

        public ContactController(IContactFacade contactFacade)
        {
            _contactFacade = contactFacade;
        }

        [HttpGet]
        [Route("")]
        public async Task<ReturnViewModel> Get()
        {
            try
            {
                var data = await _contactFacade.Get();

                var result = Mapper.Map<IEnumerable<People>, IEnumerable<ContactDTO>>(data);

                return new ReturnViewModel(HttpStatusCode.OK,
                                            result,
                                            false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<ReturnViewModel> Get(FilterDTO filter)
        {
            try
            {
                var data = await _contactFacade.GetByName(filter.Name);

                var result = Mapper.Map<IEnumerable<People>, IEnumerable<ContactDTO>>(data);

                return new ReturnViewModel(HttpStatusCode.OK,
                                            result,
                                            false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }

        [HttpPost]
        [Route("save")]
        public ReturnViewModel Save([FromBody]ContactDTO contact)
        {
            try
            {
                var app = AutoMapper.Mapper.Map<ContactDTO, Infrastructure.Domain.Data.People>(contact);

                _contactFacade.Create(app, contact.Applications);

                return new ReturnViewModel(HttpStatusCode.OK, "Save Successfully", false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }

        [HttpPut]
        [Route("edit")]
        public ReturnViewModel Edit([FromBody]ContactDTO contact)
        {
            try
            {
                var app = AutoMapper.Mapper.Map<ContactDTO, Infrastructure.Domain.Data.People>(contact);

                _contactFacade.Update(contact.Id, app);

                return new ReturnViewModel(HttpStatusCode.OK, "Update Successfully", false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ReturnViewModel Delete([FromBody]DeleteDTO contact)
        {
            try
            {
                _contactFacade.Remove(contact.Id);

                return new ReturnViewModel(HttpStatusCode.OK, new { deletado = true }, false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }
    }
}