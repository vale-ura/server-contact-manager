using ContactManager.Infrastructure.Domain.DTO.Contact;
using ContactManager.Infrastructure.Domain.DTO.Filters;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Facade.Interface.Contact;
using ContactManager.API.Helpers;
using System.Net;

namespace ContactManager.API.Controllers.Contacts
{
    [Route("v1/contact")]
    public class ContactController : Controller
    {
        private readonly IContactFacade _contactFacade;

        public ContactController( IContactFacade contactFacade)
        {
            _contactFacade = contactFacade;
        }

        [HttpGet]
        [Route("")]
        public ReturnViewModel Get(FilterDTO filters)
        {
            try
            {
                return new ReturnViewModel(HttpStatusCode.OK,_contactFacade.Get(filters),false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest,ex.Message,true);
            }
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save(ContactDTO contact)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("edit")]
        public IActionResult Edit(ContactDTO contact)
        {
            return Ok();
        }
        
        [HttpDelete]
        [Route("delete")]
        public ReturnViewModel Delete(string id)
        {
            try
            {
                var data = _contactFacade.Remove(id);

                return new ReturnViewModel(HttpStatusCode.OK,new{ deletado = data },false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest,ex.Message,true);
            }
        }
    }
}