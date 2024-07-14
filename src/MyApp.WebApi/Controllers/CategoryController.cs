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
        
        [HttpGet("GetAllWithSubCategoriesWithPaging")]
        public async Task<IActionResult> GetAllWithSubCategories(int pageNo, int pageSize)
        {
            var allCategories = await _serviceManager.CategoryService.GetAllWithSubCategories(pageNo, pageSize);
            return Ok(new
            {
                TotalCount = _serviceManager.CategoryService.TotalCount(),
                Categories = allCategories
            });
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
        
        [HttpGet("GetSelectedCategoriesWithPaging")]
        public async Task<IActionResult> GetSelectedCategoriesWithPaging(int pageNo, int pageSize)
        {
            var selectedCategories = await _serviceManager.CategoryService.GetSelectedCategories(pageNo,pageSize);
            return Ok(new
            {
                TotalCount = _serviceManager.CategoryService.TotalCount(),
                Categories = selectedCategories
            });
        }
        
        [HttpGet("GetSelectedCategories")]
        public async Task<IActionResult> GetSelectedCategories()
        {
            var selectedCategories = await _serviceManager.CategoryService.GetSelectedCategories();
            return Ok(selectedCategories);

        }
        
        [HttpGet("GetAllWithPaging")]
        public async Task<IActionResult> GetAllWithPaging(int pageNo, int pageSize)
        {
            var allCategories = await _serviceManager.CategoryService.GetAllCategories(pageNo, pageSize);
            return Ok(new
            {
                TotalCount = _serviceManager.CategoryService.TotalCount(),
                Categories = allCategories
            });
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
            try
            {
                _serviceManager.CategoryService.DeleteCategory(Id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest(new { msg = "category has products " });
            }
         
        }

    }
}
