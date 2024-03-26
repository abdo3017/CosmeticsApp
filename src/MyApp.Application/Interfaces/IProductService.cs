using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Domain.Entities;
using System.Runtime.InteropServices;

namespace MyApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<productDTO> CreateProduct(CreateProductDTO pro );
        void UpdateProduct(productDTO pro);
        void DeleteProduct(int pro);
        int TotalCount(int count = 0);
        Task<List<productDTO>> GetAllProducts(int pageNo, int pageSize);
        Task<productDTO?> GetProductById(int id);
        Task<ProductDetailsDTO> GetProductDetails(int id);
        Task<List<productDTO>> GetProductsByFilter(ProductFilter filters, int pageNo, int pageSize);
        Task<List<productDTO>> GetProductsByCategoryId(int catId);
        Task<List<productDTO>> GetProductsByBrandId(int brandId);
        List<int> GetProductPriceRange();
        Task<List<productDTO>> GetBestProducts(int pageNo, int pageSize);
        Task<List<productDTO>> GetRecentProducts(int pageNo, int pageSize);


    }
}