﻿using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Application.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyApp.Application.Services
{
    public class BrandService : BaseService<Brand, int>, IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BrandDTO> CreateBrand(BrandDTO req)
        {
            var Brand = req.Map();

            var AddedBrand = await AddAsync(Brand);

            var dtoBrand = AddedBrand.Map();

            return dtoBrand;
        }

        public void DeleteBrand(BrandDTO req)
        {
            var Brand = req.Map();

            Delete(Brand);
        }

        public async Task<List<BrandDTO>> GetAllBrands()
        {
            var categories = await _repository.GetAllAsync();

            var categoriesDto = categories.Select(s => s.Map()).ToList();

            return categoriesDto;
        }

        public async Task<BrandDTO?> GetBrandById(int id)
        {
            var specification = BrandSpecifications.GetBrandById(id);

            var Brand = await _repository.FirstOrDefaultAsync(specification);

            var dtoBrand = Brand?.Map();

            return dtoBrand;
        }

        public async Task<BrandDTO?> GetBrandByName(string name)
        {
            var specification = BrandSpecifications.GetBrandByName(name);

            var Brand = await _repository.FirstOrDefaultAsync(specification);

            var dtoBrand = Brand?.Map();

            return dtoBrand;
        }
        public async Task<List<BrandDTO>?> GetBrandsByCategoryId(int id)
        {
            var specification = CategorySpecifications.GetCategoryById(id);
            specification.AddInclude(s => s.Brands);
            var catRepo = _unitOfWork.Repository<Category, int>();

            var category = await catRepo.FirstOrDefaultAsync(specification);
            var brandsCategory = category?.Brands.Select(c => c.Map()).ToList();

            return brandsCategory;
        }
        public void UpdateBrand(BrandDTO req)
        {
            var Brand = req.Map();

            Update(Brand);
        }

        public async Task UploadImg(int BrandId,IFormFile file)
        {
            byte[] photoData = await GalleryMapper.ConvertFormFileToBarr(file);
            var specification = BrandSpecifications.GetBrandById(BrandId);
            var Brand = await _repository.FirstOrDefaultAsync(specification);
            Brand.Image = photoData;
            _unitOfWork.SaveChanges();
        }
    }
}
