using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Application.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class CategoryService : BaseService<Category, int>, ICategoryService
    {

        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<CategoryDTO> CreateCategory(CategoryDTO req)
        {
            var category = req.Map();

            var AddedCategory = await AddAsync(category);

            var dtoCategory = AddedCategory.Map();

            return dtoCategory;
        }

        public void DeleteCategory(CategoryDTO req)
        {
            var category = req.Map();

            Delete(category);
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var categories = await _repository.GetAllAsync();

            var categoriesDto = categories.Select(s => s.Map()).ToList();

            return categoriesDto;
        }

        public async Task<List<BrandDTO>?> GetBrandsByCategoryId(int id)
        {
            var specification = CategorySpecifications.GetCategoryById(id);
            specification.AddInclude(s => s.Brands);

            var category = await _repository.FirstOrDefaultAsync(specification);
            var brandsCategory = category?.Brands.Select(c => c.Map()).ToList();

            return brandsCategory;
        }

        public async Task<CategoryDTO?> GetCategoryById(int id)
        {
            var specification = CategorySpecifications.GetCategoryById(id);

            var category = await _repository.FirstOrDefaultAsync(specification);

            var dtoCategory = category?.Map();

            return dtoCategory;
        }

        public async Task<CategoryDTO?> GetCategoryByName(string name)
        {
            var specification = CategorySpecifications.GetCategoryByName(name);

            var category = await _repository.FirstOrDefaultAsync(specification);

            var dtoCategory = category?.Map();

            return dtoCategory;
        }

        public void UpdateCategory(CategoryDTO req)
        {
            var category = req.Map();

            Update(category);
        }
    }
}
