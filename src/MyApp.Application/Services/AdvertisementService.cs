using MyApp.Application.Core.Services;
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
using MyApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using MyApp.Application.Core.Specifications;

namespace MyApp.Application.Services
{
    public class AdvertisementService : BaseService<Advertisement, int>, IAdvertisementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private int totalCount = 0;

        public AdvertisementService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AdvertisementDTO> CreateAdvertisement(AdvertisementDTO req)
        {
            var Advertisement = req.Map();

            var AddedAdvertisement = await AddAsync(Advertisement);

            var dtoAdvertisement = AddedAdvertisement.Map();

            return dtoAdvertisement;
        }

        public void DeleteAdvertisement(int id)
        {

            DeleteById(id);
        }

        public async Task<List<AdvertisementDTO>> GetAllAdvertisements(int pageNo = 0, int pageSize = 0)
        {

            var spec = new BaseSpecification<Advertisement>();
            spec.ApplyPaging(pageNo, pageSize);
            var Advertisements = await _repository.ListAsync(spec);
            var AdvertisementsDto = Advertisements.Select(s => s.Map()).ToList();
            return AdvertisementsDto;
        }

        public async Task<List<AdvertisementDTO>?> GetFilteredAdvertisements(AdvertisementFilter filter, int pageNo, int pageSize)
        {
            var specification = AdvertisementSpecifications.GetAdvertisementsByFilters(filter, pageNo, pageSize);
            var advertisements = await _repository.ListAsync(specification);
            totalCount = specification.TotalCount;
            var advertisementsDTO = advertisements.Select(c => c.Map()).ToList();

            return advertisementsDTO;
        }


        public async Task<AdvertisementDTO?> GetAdvertisementById(int id)
        {
            var specification = AdvertisementSpecifications.GetAdvertisementById(id);

            var Advertisement = await _repository.FirstOrDefaultAsync(specification);

            var dtoAdvertisement = Advertisement?.Map();

            return dtoAdvertisement;
        }

        public async void UpdateAdvertisement(AdvertisementDTO dto)
        {

            var specification = AdvertisementSpecifications.GetAdvertisementById(dto.Id);

            var Advertisement = await _repository.FirstOrDefaultAsync(specification);

            if(Advertisement != null)
            {
                Advertisement.Id = dto.Id;
                Advertisement.BrandId = dto.BrandId?? Advertisement.BrandId;
                Advertisement.Tag = dto.Tag?? Advertisement.Tag;
                Advertisement.CategoryId = dto.CategoryId ?? Advertisement.CategoryId;
                Advertisement.Discount = dto.Discount ?? Advertisement.Discount;
            }
            Update(Advertisement);
        }

        public async Task UploadImg(int advertisementId, IFormFile file)
        {
            byte[] photoData = await GalleryMapper.ConvertFormFileToBarr(file);
            var specification = AdvertisementSpecifications.GetAdvertisementById(advertisementId);
            var Adv = await _repository.FirstOrDefaultAsync(specification);
            Adv.Img = photoData;
            _unitOfWork.SaveChanges();
        }
        public int TotalCount()
        {
            return totalCount;
        }

        public async Task<int> GetTotalCount()
        {
            var totalCount = 0;
            var Advertisements = await _repository.GetAllAsync();
            totalCount = Advertisements.Count();
            return totalCount;
        }
    }
}
