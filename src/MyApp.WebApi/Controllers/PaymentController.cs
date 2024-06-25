using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PaymentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpPost("ExecutePayment")]
        public async Task<IActionResult> ExecutePayment([FromBody] PaymentInfoDto paymentInfoDto)
        {
            return Ok(await _serviceManager.PaymentService.ExecutePayment(paymentInfoDto));
        }
        
    }
}
