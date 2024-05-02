using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;

namespace MyApp.WebApi.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("PlaceSalesOrder")]
        public async Task<IActionResult> PlaceSalesOrder([FromBody] OrderDTO data)
        {
            var  res = await _serviceManager.SalesOrderService.PlaceOrderAsync(data);
            return Ok(res);
        }
        [HttpPost("PlaceReturnOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDTO data)
        {
            var res = await _serviceManager.ReturnOrderService.PlaceOrderAsync(data);
            return Ok(res);
        }

    }
}
