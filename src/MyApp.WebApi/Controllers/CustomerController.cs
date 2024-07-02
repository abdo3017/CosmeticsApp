using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;


namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CustomerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int pageNo , int pageSize)
        { 
            var res = await _serviceManager.CustomerService.GetCustomers(pageNo, pageSize);
            return Ok(res);
        }

        [HttpGet("GetCustomerCount")]
        public async Task<IActionResult> GetCustomerCount()
        {
            var res = await _serviceManager.CustomerService.GetCustomersCount();
            return Ok(res);
        }


    }
}
