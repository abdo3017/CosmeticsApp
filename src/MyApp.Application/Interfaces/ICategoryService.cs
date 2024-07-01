using Microsoft.AspNetCore.Http;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces
{
    public interface ICategoryService
    {
        int TotalCount();
        Task<CategoryDTO> CreateCategory(CreateCategoryDTO req);
        void UpdateCategory(CategoryDTO req);
        void DeleteCategory(int id);
        Task<List<CategoryDTO>> GetAllCategories(int pageNo = 0, int pageSize = 0);
        Task<List<CategoryDTO>> GetSelectedCategories(int pageNo = 0, int pageSize = 0);
        Task CreateImg(int CatId, IFormFile file);
        Task<CategoryDTO?> GetCategoryById(int id);
        Task<CategoryDTO?> GetCategoryByName(string name);
        Task<List<CategoryDTO>?> GetAllWithSubCategories(int pageNo = 0, int pageSize = 0); 
        Task<CategoryDTO> GetByIdWithSubCategories(int id); 
        Task<List<CategoryDTO>?> GetCategoriesByBrandId(int id);
    }
}