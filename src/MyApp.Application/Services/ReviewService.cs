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
using Microsoft.AspNetCore.Http;
using MyApp.Domain.Models;

namespace MyApp.Application.Services
{
    public class ReviewService : BaseService<Review, int>, IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private int totalCount = 0;

        public ReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReviewDTO> CreateReview(CreateReviewDTO req)
        {
            var Review = req.Map();

            var AddedReview = await AddAsync(Review);

            var dtoReview = AddedReview.Map();

            return dtoReview;
        }

        public void DeleteReview(int id)
        {
            DeleteById(id);
        }

        public async Task<List<ReviewDTO>> GetAllReviews(int pageNo = 0, int pageSize = 0)
        {
            var specification = ReviewSpecifications.GetReviewWithUser();
            specification.ApplyPaging(pageNo, pageSize);
            var reviews = await _repository.ListAsync(specification);
            totalCount = specification.TotalCount;
            var reviewsDto = reviews.Select(s => s.Map()).ToList();

            return reviewsDto;
        }

        public async Task<ReviewDTO?> GetReviewById(int id)
        {
            var specification = ReviewSpecifications.GetReviewById(id);

            var Review = await _repository.FirstOrDefaultAsync(specification);

            var dtoReview = Review?.Map();

            return dtoReview;
        }
        public async Task<List<ReviewDTO>> GetReviewsByProductId(int productId, int pageNo = 0, int pageSize = 0)
        {
            var specification = ReviewSpecifications.GetReviewsByProductId(productId);
            specification.ApplyPaging(pageNo, pageSize);
            var reviews = await _repository.ListAsync(specification);
            totalCount = specification.TotalCount;

            var reviewsDto = reviews.Select(s => s.Map()).ToList();

            return reviewsDto;
        }
        
        public async Task<List<ReviewDTO>> GetReviewsByCustomerId(int customerId, int pageNo = 0, int pageSize = 0)
        {
            var specification = ReviewSpecifications.GetReviewsByCustomerId(customerId);
            specification.ApplyPaging(pageNo, pageSize);
            var reviews = await _repository.ListAsync(specification);
            totalCount = specification.TotalCount;

            var reviewsDto = reviews.Select(s => s.Map()).ToList();

            return reviewsDto;
        }
        
        public void UpdateReview(ReviewDTO req)
        {
            var Review = req.Map();

            Update(Review);
        }
        public int TotalCount()
        {
            return totalCount;
        }
    }
}
