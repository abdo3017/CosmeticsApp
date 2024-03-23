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

         async Task<productDTO> IProductService.CreateProduct(productDTO pro)
        {

            Product product = pro.Map();
            var AddedProduct = await AddAsync(product);
            var AddedProductDto = AddedProduct.Map();
            return AddedProductDto;
        }

        void IProductService.DeleteProduct(int proID)
        {
            DeleteById(proID);
        }

       async Task<List<productDTO>> IProductService.GetAllProducts(int pageNo ,int  pageSize)
        {
            var spec = ProductSpecifications.GetProductWithImgs(pageNo, pageSize);
            var Products = await _repository.ListAsync(spec);// why not iquerable
            var ProductsDto = Products.Select(s => s.Map()).ToList();
            return ProductsDto;
        }

        async Task<List<productDTO>> IProductService.GetProductsByFilter(ProductFilter filters)
        {
            var spec = ProductSpecifications.GetProductByFilters(filters);
            var Products = await _repository.ListAsync(spec);// why not iquerable
            var categoriesDto = Products.Select(s => s.Map()).ToList();
            return categoriesDto;
        }

        async Task<productDTO?> IProductService.GetProdcutById(int id)
        {
            var spec = ProductSpecifications.GetProductByIdWithImgs(id);
            var product = await _repository.FirstOrDefaultAsync(spec);
            var productDto = product?.Map();
            return productDto;
        }

        async Task<ProductDetailsDTO> IProductService.GetProdcutDetails(int id)
        {
            var spec = ProductSpecifications.GetProductByIdWithImgs(id);
            var product = await _repository.FirstOrDefaultAsync(spec);
            var productDtoDetails = product?.MapToProDetails();
            return productDtoDetails;
        }

        void IProductService.UpdateProduct(productDTO pro)
        {
             var product = pro.Map();
            Update(product);
        }

        List<int> IProductService.GetProductPriceRange()
        {
            //var product =   _repository._dbContext;
            return [1, 22];
        }
    }
}