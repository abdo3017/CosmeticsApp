using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using System.Security.Cryptography;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentCostController :ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ShipmentCostController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpGet("GetShipmentLocations")]
        public async Task<IActionResult> GetShipmentLocations()
        {
            var res = await _serviceManager.ShipmentCostService.GetShipmentAddress();
            return Ok(res);
        }

        [HttpGet("GetShipmentCostCount")]
        public async Task<IActionResult> GetShipmentCostCount()
        {
            var res = await _serviceManager.ShipmentCostService.GetShipmentsCostCount();
            return Ok(res);
        }

        [HttpGet("GetShipmentCost")]
        public async Task<IActionResult> GetShipmentLocations(int pageNo, int pageSize)
        {
            var res = await _serviceManager.ShipmentCostService.GetShipmentsAsync(pageNo, pageSize);
            return Ok(res);
        }

        [HttpPost("GetShipmentCost")]
        public async Task<IActionResult> GetShipmentLocations(ShipmentCostDTO body)
        {
            var res = await _serviceManager.ShipmentCostService.Create(body);
            return Ok(res);
        }




        [HttpPut("SetShipmentCost{Id}/{Cost}")]
        public async Task<IActionResult> CreateCost(int  Id , decimal Cost)
        {
            var res = await _serviceManager.ShipmentCostService.AddCost(Id, Cost);  
            return Ok(res);
        }


        [HttpGet("GetshipmentCostByAddresssID")]
       public async Task<IActionResult> GetshipmentCostByAddresssID(int Id)
        {
            var res = await _serviceManager.ShipmentCostService.GetShipmentCostByAddressId(Id);
            return Ok(res);
        }


        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> delete(int Id)
        {
             _serviceManager.ShipmentCostService.DeleteAsync(Id);
            return Ok();
        }

    }
}
