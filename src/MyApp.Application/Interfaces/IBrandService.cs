using Microsoft.AspNetCore.Http;
using MyApp.Application.Models.DTOs;

namespace MyApp.Application.Interfaces
{
    public interface IBrandService
    {
        Task<BrandDTO> CreateBrand(BrandDTO req);
        void UpdateBrand(BrandDTO req);
        void DeleteBrand(int id);
        int TotalCount();

        Task<List<BrandDTO>> GetAllBrands(int pageNo = 0, int pageSize = 0);
        Task<BrandDTO?> GetBrandById(int id);
        Task<BrandDTO?> GetBrandByName(string name);
        Task<List<BrandDTO>?> GetBrandsByCategoryId(int id);
        Task UploadImg(int BrandId, IFormFile file);
    }
        
}