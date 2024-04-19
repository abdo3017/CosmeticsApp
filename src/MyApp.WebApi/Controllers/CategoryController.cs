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

        [HttpGet("GetAllWithSubCategories")]
        public async Task<IActionResult> GetAllWithSubCategories()
        {
            var allCategories = await _serviceManager.CategoryService.GetAllWithSubCategories();
            return Ok(allCategories);
        }
        [HttpGet("GetCategoriesByBrandId")]
        public async Task<IActionResult> GetCategoriesByBrandId(int id)
        {
            var allCategories = await _serviceManager.CategoryService.GetCategoriesByBrandId(id);
            return Ok(allCategories);

        }
        [HttpGet("GetSelectedCategories")]
        public async Task<IActionResult> GetSelectedCategories()
        {
            var selectedCategories = await _serviceManager.CategoryService.GetSelectedCategories();
            return Ok(selectedCategories);

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
        [HttpGet("GetByIdWithSubCategories")]
        public async Task<IActionResult> GetByIdWithSubCategories(int id)
        {
            var cat = await _serviceManager.CategoryService.GetByIdWithSubCategories(id);
            return Ok(cat);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var cat = await _serviceManager.CategoryService.GetCategoryByName(name);
            return Ok(cat);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateCategoryDTO category)
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
        public IActionResult Delete(int Id)
        {
            _serviceManager.CategoryService.DeleteCategory(Id);
            return Ok();
        }

    }
}
