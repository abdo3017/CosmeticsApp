using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Application.Services;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Identity.Models;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;// test 
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDTO category)
        {
            var addedCat = await _serviceManager.CategoryService.CreateCategory(category);
            return Ok(addedCat);
        }


    }
}
