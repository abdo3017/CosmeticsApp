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
using Microsoft.EntityFrameworkCore;





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
        public async Task<productDTO?> GetProductByIdASnoTracking(int id)
        {
            var spec = ProductSpecifications.GetProductByIdWithImgs(id);
            var product = await _repository.FirstOrDefaultNoTrackingAsync(spec);
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
            totalCount = spec.TotalCount;
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public async Task<List<productDTO>> GetProductsByBrandId(int brandId, int pageNo, int pageSize)
        {
            var spec = ProductSpecifications.GetProductsByBrandId(brandId, pageNo, pageSize);
            var products = await _repository.ListAsync(spec);
            totalCount = spec.TotalCount;
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public int TotalCount()
        {
            return totalCount;
        }
        public async Task<List<productDTO>> GetBestProducts(int pageNo, int pageSize)
        {
            var spec = ProductSpecifications.GetProductWithRateGt4_5(pageNo, pageSize);
            var products = await _repository.ListAsync(spec);
            totalCount = spec.TotalCount;
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public async Task<List<productDTO>> GetRecentProducts(int pageNo, int pageSize)
        {
            var spec = ProductSpecifications.GetRecentProduct(pageNo, pageSize);
            var products = await _repository.ListAsync(spec);
            totalCount = spec.TotalCount;
            var productsDto = products.Select(s => s.Map()).ToList();
            return productsDto;
        }

        public async Task<SearchResultDTO> SearchResult(string searchTxt)
        {
            var catRepo = _unitOfWork.Repository<Category, int>();
            var brandRepo = _unitOfWork.Repository<Brand, int>();

            var ProSpec = ProductSpecifications.GetProductByName(searchTxt);
            var ProductsResult = await _repository.ListAsync(ProSpec);

            var CatSpec = CategorySpecifications.GetCategoryByNameLike(searchTxt);
            var CategoryResult = await catRepo.ListAsync(CatSpec);

            var BrandSpec  = BrandSpecifications.GetBrandByNameLike(searchTxt);
            var BrandResult = await brandRepo.ListAsync(BrandSpec);

            return new SearchResultDTO()
            {
                Products = ProductsResult.Select(p => p.MapTOSearchResult()).ToList(),
                Categories = CategoryResult.Select(p => p.MapTOSearchResult()).ToList(),
                Brands = BrandResult.Select(p => p.MapTOSearchResult()).ToList()
            };
        }



            public async Task<bool> IsAvailableProduct(OrderDetailsDTO DTO)
        {
            bool isValid;
            var attrValueRepo = _unitOfWork.Repository<AttributeValue, int>();
            var attrValue = await attrValueRepo.GetByIdAsync(DTO.AttrValueId);
            var productDto = await GetProductByIdASnoTracking(DTO.ProductId);
            if (attrValue != null && DTO.AttrValueId != -1)
            {
                isValid = attrValue.Qty >= DTO.ProductQty;
                if (isValid)
                {
                    attrValue.Qty -= DTO.ProductQty;
                    attrValueRepo.Update(attrValue);
                }
            }
            else
                isValid = productDto.Qty >= DTO.ProductQty;

            if (isValid)
            {
                attrValue.Product.Qty -= DTO.ProductQty;
                UpdateProduct(attrValue.Product.Map());
                //_repository.Update(attrValue.Product);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }
    }
}