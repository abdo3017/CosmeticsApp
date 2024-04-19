using MyApp.Application.Models.DTOs;


namespace MyApp.Application.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDTO> CreateReview(CreateReviewDTO req);
        void UpdateReview(ReviewDTO req);
        void DeleteReview(int id);
        Task<List<ReviewDTO>> GetAllReviews();
        Task<List<ReviewDTO>> GetReviewsByCustomerId(int customerId);
        Task<List<ReviewDTO>> GetReviewsByProductId(int productId);
        Task<ReviewDTO?> GetReviewById(int id);
    }
}