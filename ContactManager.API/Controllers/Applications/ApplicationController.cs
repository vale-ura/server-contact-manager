using ContactManager.Infrastructure.Domain.DTO.Application;
using ContactManager.Infrastructure.Domain.DTO.Filters;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Facade.Interface.Application;
using ContactManager.API.Helpers;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;

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
        [ResponseCache(CacheProfileName = "Default30")]
        public async Task<ReturnViewModel> Get([FromBody]FilterDTO filter)
        {
            try
            {
                var data = await _application.GetByName(filter.Name);

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
        [Route("")]
        [ResponseCache(CacheProfileName = "Default30")]
        public async Task<ReturnViewModel> Get()
        {
            try
            {
                var data = await _application.Get();

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
        public ReturnViewModel Save([FromBody]ApplicationDTO application)
        {
            try
            {
                var app = Mapper.Map<ApplicationDTO, Infrastructure.Domain.Data.Applications>(application);

                _application.Create(app);

                return new ReturnViewModel(HttpStatusCode.OK, "Save successfully", false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }

        [HttpPut]
        [Route("edit")]
        public ReturnViewModel Edit([FromBody]ApplicationDTO application)
        {
            try
            {
                var app = AutoMapper.Mapper.Map<ApplicationDTO, Infrastructure.Domain.Data.Applications>(application);

                _application.Update(application.Id, app);

                return new ReturnViewModel(HttpStatusCode.OK, "Update Successfully", false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ReturnViewModel Delete([FromBody]DeleteDTO application)
        {
            try
            {
                _application.Remove(application.Id);

                return new ReturnViewModel(HttpStatusCode.OK, new { deletado = true }, false);
            }
            catch (System.Exception ex)
            {
                return new ReturnViewModel(HttpStatusCode.BadRequest, ex.Message, true);
            }
        }
    }
}