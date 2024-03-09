using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BrandController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allBrands = await _serviceManager.BrandService.GetAllBrands();
            return Ok(allBrands);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _serviceManager.BrandService.GetBrandById(id);
            return Ok(cat);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var cat = await _serviceManager.BrandService.GetBrandByName(name);
            return Ok(cat);
        }

        [HttpGet("GetAllCategoriesBrand")]
        public async Task<IActionResult> GetAllCategoriesBrand(int id)
        {
            var allCategories = await _serviceManager.BrandService.GetCategoriesByBrandId(id);
            return Ok(allCategories);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(BrandDTO brand)
        {
            var addedBrand = await _serviceManager.BrandService.CreateBrand(brand);
            return Created();
        }

        [HttpPut("Update")]
        public IActionResult Update(BrandDTO brand)
        {
            _serviceManager.BrandService.UpdateBrand(brand);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(BrandDTO brand)
        {
            _serviceManager.BrandService.DeleteBrand(brand);
            return Ok();
        }

    }
}
