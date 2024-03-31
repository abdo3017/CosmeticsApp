using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.DTOs;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ReviewController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allReviews = await _serviceManager.ReviewService.GetAllReviews();
            return Ok(allReviews);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _serviceManager.ReviewService.GetReviewById(id);
            return Ok(cat);
        }

        [HttpGet("GetByCustomerId")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var cat = await _serviceManager.ReviewService.GetReviewsByCustomerId(customerId);
            return Ok(cat);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateReviewDTO Review)
        {
            var addedReview = await _serviceManager.ReviewService.CreateReview(Review);
            return Created();
        }

        [HttpPut("Update")]
        public IActionResult Update(ReviewDTO Review)
        {
            _serviceManager.ReviewService.UpdateReview(Review);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(ReviewDTO Review)
        {
            _serviceManager.ReviewService.DeleteReview(Review);
            return Ok();
        }

    }
}
