using MyApp.Application.Models.DTOs;

namespace MyApp.Application.Interfaces
{
    public interface IBrandService
    {
        Task<BrandDTO> CreateBrand(BrandDTO req);
        void UpdateBrand(BrandDTO req);
        void DeleteBrand(BrandDTO req);
        Task<List<BrandDTO>> GetAllBrands();
        Task<BrandDTO?> GetBrandById(int id);
        Task<BrandDTO?> GetBrandByName(string name);
        Task<List<CategoryDTO>?> GetCategoriesByBrandId(int id);
    }
}