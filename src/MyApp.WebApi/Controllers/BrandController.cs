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
        [HttpGet("GetAllWithPaging")]
        public async Task<IActionResult> GetAllWithPaging(int pageNo, int pageSize)
        {
            var allBrands = await _serviceManager.BrandService.GetAllBrands(pageNo,pageSize);
            return Ok(new
            {
                TotalCount = _serviceManager.BrandService.TotalCount(),
                Brands = allBrands
            });
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

        [HttpGet("GetBrandsByCategoryId")]
        public async Task<IActionResult> GetBrandsByCategoryId(int id)
        {
            var allBrands = await _serviceManager.BrandService.GetBrandsByCategoryId(id);
            return Ok(allBrands);

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
        public IActionResult Delete(int id)
        {
            _serviceManager.BrandService.DeleteBrand(id);
            return Ok();
        }

        [HttpPost("UploadImg/{BrandId}")]
        public async Task<IActionResult> UploadImage(int BrandId , IFormFile file)
        {
           await _serviceManager.BrandService.UploadImg(BrandId, file); 
            return Ok();
        }

    }
}
