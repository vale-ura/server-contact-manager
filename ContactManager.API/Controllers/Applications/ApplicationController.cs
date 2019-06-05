using ContactManager.Infrastructure.Domain.DTO.Application;
using ContactManager.Infrastructure.Domain.DTO.Filters;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Facade.Interface.Application;
using ContactManager.API.Helpers;
using System.Net;

namespace ContactManager.API.Controllers.Applications
{
    [Route("v1/application")]
    public class ApplicationController : Controller
    {
        private readonly IApplicationFacade _application;

        public ApplicationController(IApplicationFacade application)
        {
            _application = application;
        }

        [HttpGet]
        [Route("")]
        // GET
        public ReturnViewModel Get(FilterAppDTO filter)
        {
            try
            {
                return new ReturnViewModel(HttpStatusCode.OK,
                                           _application.GetByName(filter.Name),
                                           false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save(ApplicationDTO application)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("edit")]
        public IActionResult Edit(ApplicationDTO application)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public ReturnViewModel Delete(string id)
        {
            try
            {
                _application.Remove(id);

                return new ReturnViewModel(HttpStatusCode.OK, new { deletado = true }, false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }
    }
}