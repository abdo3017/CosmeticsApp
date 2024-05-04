using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;

namespace MyApp.WebApi.Controllers
{
    public class LocationController:ControllerBase
    {
        private IServiceManager _serviceManager;
       public LocationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost("CreateAddress")]
        public async Task<IActionResult> CreateAddress([FromBody] AddressDto dto)
        {
           var res = await _serviceManager.LocationService.Create(dto);    
            return Ok(res);
        }

        [HttpGet("AddressByCustNo")]
        public async Task< IActionResult> GetAddressByCustomerId(int customerId)
        {
            var res = await _serviceManager.LocationService.GetAllByCustomerIdAsync(customerId);
            return Ok(res);
        }

        [HttpDelete("deleteAddress")]
        public IActionResult DeleteAddress(int addressId)
        {
             _serviceManager.LocationService.Delete(addressId);
            return Ok();
        }









    }
}
