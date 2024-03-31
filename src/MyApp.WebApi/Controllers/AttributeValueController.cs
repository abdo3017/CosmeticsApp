using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttributeValueController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AttributeValueController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AttributeValueDTO attr)
        {
          var res = await   _serviceManager.AttributeValueService.CreateAttrVal(attr);
            return Ok(res);
        }

        [HttpPut]
        public IActionResult Update(AttributeValueDTO attr)
        {
            _serviceManager.AttributeValueService.UpdateAttrVal(attr);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(AttributeValueDTO attr)
        {
            _serviceManager.AttributeValueService.DeleteAttrVal(attr);
            return Ok();
        }
    }

}
