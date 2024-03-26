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
        private readonly IUnitOfWork _unitOfWork;
        private int totalCount = 0;
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<productDTO> CreateProduct(CreateProductDTO pro)
        {

            Product product = pro.Map();
            var catRepo = _unitOfWork.Repository<Category, int>();
            var AddedProduct = await AddAsync(product);
            var cat = await catRepo.GetByIdAsync(product.CategoryId);
            var AddedProductDto = AddedProduct.Map();
            return AddedProductDto;
        }

        public void DeleteProduct(int proID)
        {
            DeleteById(proID);
        }

        public async Task<List<productDTO>> GetAllProducts(int pageNo, int pageSize)
        {
            var spec = ProductSpecifications.GetProductWithPaging(pageNo, pageSize);
            var products = await _repository.ListAsync(spec);
            totalCount = spec.TotalCount;
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public async Task<List<productDTO>> GetProductsByFilter(ProductFilter filters, int pageNo, int pageSize)
        {
            var spec = ProductSpecifications.GetProductByFilters(filters, pageNo, pageSize);
            var products = await _repository.ListAsync(spec);
            totalCount = spec.TotalCount;
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

        public async Task<List<productDTO>> GetProductsByCategoryId(int catId, int pageNo, int pageSize)
        {
            var spec = ProductSpecifications.GetProductsByCategoryId(catId, pageNo, pageSize);
            var products = await _repository.ListAsync(spec);
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public async Task<List<productDTO>> GetProductsByBrandId(int brandId, int pageNo, int pageSize)
        {
            var spec = ProductSpecifications.GetProductsByBrandId(brandId, pageNo, pageSize);
            var products = await _repository.ListAsync(spec);
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public int TotalCount()
        {
            return totalCount;
        }
        public async Task<List<productDTO>> GetBestProducts(int pageNo , int pageSize)
        {
            var spec = ProductSpecifications.GetProductWithRateGt4_5(pageNo, pageSize);
            var products = await _repository.ListAsync(spec);
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public async Task<List<productDTO>> GetRecentProducts(int pageNo, int pageSize)
        {
            var spec = ProductSpecifications.GetRecentProduct(pageNo, pageSize);
            var products = await _repository.ListAsync(spec);
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }
    }
}