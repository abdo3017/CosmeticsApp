using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Domain.Specifications;
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
            var specification = CategorySpecifications.GetCategoryByName(req.Name);
            var parentCategory =await _repository.FirstOrDefaultAsync(specification);
            
            var category= req.Map();
            category.ParentId = parentCategory?.Id;
            
            var AddedCategory= await AddAsync(category);
            var dtoCategory = AddedCategory.Map();
            dtoCategory.Parent = req.Name;
            
            return dtoCategory;
        }
    }
}
