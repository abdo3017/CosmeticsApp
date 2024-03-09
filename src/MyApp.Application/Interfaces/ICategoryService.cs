using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> CreateCategory(CategoryDTO req);
        void UpdateCategory(CategoryDTO req);
        void DeleteCategory(CategoryDTO req);
        Task<List<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO?> GetCategoryById(int id);
        Task<CategoryDTO?> GetCategoryByName(string name);
        Task<List<BrandDTO>?> GetBrandsByCategoryId(int id);
    }
}