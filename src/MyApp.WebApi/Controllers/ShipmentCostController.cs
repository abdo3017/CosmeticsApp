﻿using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Domain.Entities;
using System.Security.Cryptography;

namespace MyApp.WebApi.Controllers
{
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

        [HttpGet("GetShipmentCost")]
        public async Task<IActionResult> GetShipmentLocations(int pageNo, int pageSize)
        {
            var res = await _serviceManager.ShipmentCostService.GetShipmentsAsync(pageNo, pageSize);
            return Ok(res);
        }

        [HttpPut("SetShipmentCost{Id}/{Cost}")]
        public async Task<IActionResult> CreateCost(int  Id , decimal Cost)
        {
            var res = await _serviceManager.ShipmentCostService.AddCost(Id, Cost);  
            return Ok(res);
        }

    }
}