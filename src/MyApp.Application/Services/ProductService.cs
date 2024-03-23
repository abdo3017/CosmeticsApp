using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Application.Specifications;
using MyApp.Domain.Enums;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Interfaces;
using MyApp.Application.Core.Services;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Application.Models.Mappers;
using MyApp.Domain.Core.Specifications;

namespace MyApp.Application.Services
{
    public class ProductService : BaseService<Product, int>, IProductService
    {
      
        public ProductService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
        }

         public async Task<productDTO> CreateProduct(productDTO pro)
        {

            Product product = pro.Map();
            var AddedProduct = await AddAsync(product);
            var AddedProductDto = AddedProduct.Map();
            return AddedProductDto;
        }

        public void DeleteProduct(int proID)
        {
            DeleteById(proID);
        }

        public async Task<List<productDTO>> GetAllProducts(int pageNo ,int  pageSize)
        {
            var spec = ProductSpecifications.GetProductWithPaging(pageNo, pageSize);
            var products = await _repository.ListAsync(spec);
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public async Task<List<productDTO>> GetProductsByFilter(ProductFilter filters)
        {
            var spec = ProductSpecifications.GetProductByFilters(filters);
            var products = await _repository.ListAsync(spec);
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public async Task<productDTO?> GetProductById(int id)
        {
            var spec = ProductSpecifications.GetProductByIdWithImgs(id);
            var product = await _repository.FirstOrDefaultAsync(spec);
            var productDto = product?.Map();
            return productDto;
        }

        public async Task<ProductDetailsDTO> GetProductDetails(int id)
        {
            var spec = ProductSpecifications.GetProductByIdWithImgs(id);
            var product = await _repository.FirstOrDefaultAsync(spec);
            var productDetailsDto = product?.MapToProDetails();
            return productDetailsDto;
        }

        public void UpdateProduct(productDTO pro)
        {
             var product = pro.Map();
            Update(product);
        }

        public List<int> GetProductPriceRange()
        {
            return [1, 22];
        }

        public async Task<List<productDTO>> GetProductsByCategoryId(int catId)
        {
            var spec = ProductSpecifications.GetProductsByCategoryId(catId);
            var products = await _repository.ListAsync(spec);
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public async Task<List<productDTO>> GetProductsByBrandId(int brandId)
        {
            var spec = ProductSpecifications.GetProductsByBrandId(brandId);
            var products = await _repository.ListAsync(spec);
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }
    }
}