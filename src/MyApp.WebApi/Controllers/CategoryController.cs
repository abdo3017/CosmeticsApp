using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allCategories = await _serviceManager.CategoryService.GetAllCategories();
            return Ok(allCategories);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _serviceManager.CategoryService.GetCategoryById(id);
            return Ok(cat);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var cat = await _serviceManager.CategoryService.GetCategoryByName(name);
            return Ok(cat);
        }

        [HttpGet("GetAllBrandsCategory")]
        public async Task<IActionResult> GetAllBrandsCategory(int id)
        {
            var allBrands = await _serviceManager.CategoryService.GetBrandsByCategoryId(id);
            return Ok(allBrands);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CategoryDTO category)
        {
            var addedCategory = await _serviceManager.CategoryService.CreateCategory(category);
            return Created();
        }

        [HttpPut("Update")]
        public IActionResult Update(CategoryDTO category)
        {
            _serviceManager.CategoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(CategoryDTO category)
        {
            _serviceManager.CategoryService.DeleteCategory(category);
            return Ok();
        }

    }
}
