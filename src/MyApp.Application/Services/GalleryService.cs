using Microsoft.AspNetCore.Http;
using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Application.Specifications;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class GalleryService: BaseService<Gallery, int> , IGalleryService
    {
        public GalleryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Gallery> CreateImg(int proId, int isCover, IFormFile file)
        {
            byte[] photoData = await GalleryMapper.ConvertFormFileToBarr(file);
            Gallery gallery = new Gallery()
            {
                Image = photoData,
                IsCover = isCover == 1 ? true : false,
                ProductId = proId
            };
            var AddedImg = await AddAsync(gallery);
            return AddedImg;
        }

        public  void DeleteImg( int Id)
        {
            ///var spec = GalarySpecifications.GetProductsById(ProductId, Id); 
           // var gallaries = await _repository.ListAsync(spec);
           // var img = gallaries[0];
            //Delete(img);
            DeleteById(Id);
        }

     
    }
}
