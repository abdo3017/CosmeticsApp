using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Mappers
{
    public static class AdvertisementMapper
    {
        public static Advertisement Map(this AdvertisementDTO dto)
        {
            return new Advertisement
            {
                BrandId = dto.BrandId,
                Img = dto.Img,
                CategoryId = dto.CategoryId,
                Discount = dto.Discount,
            };
        }

        public static AdvertisementDTO Map(this Advertisement model)
        {
            return new AdvertisementDTO
            {
                BrandId = model.BrandId,
                Img = model.Img,
                CategoryId = model.CategoryId,
                Discount = model.Discount,
            };
        }
    }
}
