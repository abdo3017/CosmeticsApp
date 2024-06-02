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
        void UpdateProductWithoutSave(productDTO pro);
        void DeleteProduct(int pro);
        int TotalCount();
        Task<List<productDTO>> GetAllProducts(int pageNo, int pageSize);
        Task<productDTO?> GetProductById(int id);
        Task<ProductDetailsDTO> GetProductDetails(int id);
        Task<List<productDTO>> GetProductsByFilter(ProductFilter filters, int pageNo, int pageSize);
        Task<List<productDTO>> GetProductsByCategoryId(int catId, int pageNo, int pageSize);
        Task<List<productDTO>> GetProductsByBrandId(int brandId, int pageNo, int pageSize);
        List<int> GetProductPriceRange();
        Task<List<productDTO>> GetBestProducts(int pageNo, int pageSize);
        Task<List<productDTO>> GetRecentProducts(int pageNo, int pageSize);
        Task<SearchResultDTO> SearchResult(string searchTxt);
        Task<productDTO?> GetProductByIdAsNoTracking(int id);



    }
}