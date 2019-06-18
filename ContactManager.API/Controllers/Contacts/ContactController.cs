using ContactManager.Infrastructure.Domain.DTO.Contact;
using ContactManager.Infrastructure.Domain.DTO.Filters;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Facade.Interface.Contact;
using ContactManager.API.Helpers;
using System.Net;
using System.Threading.Tasks;
using System;

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

                return new ReturnViewModel(HttpStatusCode.OK,
                                            data,
                                            false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<ReturnViewModel> Get([FromBody]FilterDTO filter)
        {
            try
            {
                var data = await _contactFacade.Get(filter.Name);
                return new ReturnViewModel(HttpStatusCode.OK,
                                            data,
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

                _contactFacade.Create(app);

                return new ReturnViewModel(HttpStatusCode.OK, "Save Successfully", false);
            }
            catch(System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }

        [HttpPut]
        [Route("edit")]
        public ReturnViewModel Edit(ContactDTO contact)
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

                return new ReturnViewModel(HttpStatusCode.OK,new{ deletado = true },false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest,ex.Message,true);
            }
        }
    }
}