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
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public async Task<List<CategoryDTO>?> GetCategoriesByBrandId(int id)
        {
            var specification = BrandSpecifications.GetBrandById(id);
            specification.AddInclude(s => s.Categories);
            var brandRepo = _unitOfWork.Repository<Brand, int>();
            var brand = await brandRepo.FirstOrDefaultAsync(specification);
            var categoriesBrand = brand?.Categories.Select(c => c.Map()).ToList();

            return categoriesBrand;
        }

        public async Task<List<CategoryDTO>?> GetAllWithSubCategories()
        {
            var AllCategories = await _repository.GetAllAsync();

            var specification = CategorySpecifications.GetAllParentCategories();
            var parentCategories = await _repository.ListAsync(specification);
            var parentCategoriesDTO = parentCategories.Select(c => c.Map()).ToList();

            foreach (var category in parentCategoriesDTO)
            {
                ConstructSubCategories(category, AllCategories);
            }

            return parentCategoriesDTO;
        }
        public async Task<CategoryDTO?> GetByIdWithSubCategories(int id)
        {
            var Category = await _repository.GetByIdAsync(id);
            var AllCategories = await _repository.GetAllAsync();

            var CategoryDTO = Category.Map();

            ConstructSubCategories(CategoryDTO, AllCategories);

            return CategoryDTO;
        }
        private void ConstructSubCategories(CategoryDTO parentCategory, IEnumerable<Category> categories)
        {
            var subCategories = categories.Where(x => x.ParentId == parentCategory.Id);
            parentCategory.SubCategories = subCategories.Select(c => c.Map()).ToList();

            if (subCategories.Count() > 0)
            {
                foreach (var subCategory in parentCategory.SubCategories)
                {
                    ConstructSubCategories(subCategory, categories);
                }
            }

            return;
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
