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
    public static class ReviewMapper
    {
        public static Review Map(this ReviewDTO dto)
        {
            return new Review
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                Comment = dto.Comment,
                Rate = dto.Rate,
                ProductId = dto.ProductId
            };
        }

        public static ReviewDTO Map(this Review model)
        {
            return new ReviewDTO
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Comment = model.Comment,
                CustomerName = model.User.UserName,
                CreatedOn = model.CreatedOn,
                Rate = model.Rate,
                ProductId = model.ProductId
            };
        }

        public static Review Map(this CreateReviewDTO dto)
        {
            return new Review
            {
                CustomerId = dto.CustomerId,
                Comment = dto.Comment,
                Rate = dto.Rate,
                ProductId = dto.ProductId
            };
        }
    }
}
