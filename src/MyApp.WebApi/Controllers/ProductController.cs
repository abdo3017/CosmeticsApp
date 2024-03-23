﻿using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int pageNo , int pageSize)
        {
            var allProducts = await _serviceManager.ProductService.GetAllProducts(pageNo , pageSize);
            return Ok(allProducts);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var Product = await _serviceManager.ProductService.GetProductById(id);
            return Ok(Product);
        }
        [HttpGet("GetProductDetails")]
        public async Task<IActionResult> GetProductDetails(int id)
        {
            var ProductDetails = await _serviceManager.ProductService.GetProductDetails(id);
            return Ok(ProductDetails);
        }
        [HttpGet("GetPriceRange")]
        public IActionResult GetPriceRange()
        {
            var range =  _serviceManager.ProductService.GetProductPriceRange();
            return Ok(range);
        }
        [HttpGet("GetProductsByBrandId")]
        public async Task<IActionResult> GetProductsByBrandId(int brandId)
        {
            var range = await _serviceManager.ProductService.GetProductsByBrandId(brandId);
            return Ok(range);
        }
        [HttpGet("GetProductsByCategoryId")]
        public async Task<IActionResult> GetProductsByCategoryId(int catId)
        {
            var range = await _serviceManager.ProductService.GetProductsByCategoryId(catId);
            return Ok(range);
        }

        [HttpPost("FilterProducts")]
        public async Task<IActionResult> FilterProducts(ProductFilter filters)
        {
            var ProductDetails = await _serviceManager.ProductService.GetProductsByFilter(filters);
            return Ok(ProductDetails);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(productDTO productDTO)
        {
            var addedProduct= await _serviceManager.ProductService.CreateProduct(productDTO);
            return Ok(addedProduct);
        }
        [HttpPut("Update")]
        public IActionResult Update(productDTO productDTO)
        {
            _serviceManager.ProductService.UpdateProduct(productDTO);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _serviceManager.ProductService.DeleteProduct(id);
            return Ok();
        }
    }
}
