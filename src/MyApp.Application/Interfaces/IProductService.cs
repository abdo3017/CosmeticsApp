using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<productDTO> CreateProduct(productDTO pro );
        void UpdateProduct(productDTO pro);
        void DeleteProduct(int pro);
        Task<List<productDTO>> GetAllProducts(int pageNo, int pageSize);
        Task<productDTO?> GetProdcutById(int id);
        Task<ProductDetailsDTO> GetProdcutDetails(int id);
        Task<List<productDTO>> GetProductsByFilter(ProductFilter filters);
        List<int> GetProductPriceRange();


    }
}