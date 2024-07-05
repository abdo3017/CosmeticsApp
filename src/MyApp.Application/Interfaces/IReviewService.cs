using MyApp.Application.Models.DTOs;


namespace MyApp.Application.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDTO> CreateReview(CreateReviewDTO req);
        void UpdateReview(ReviewDTO req);
        int TotalCount();
        void DeleteReview(int id);
        Task<List<ReviewDTO>> GetAllReviews(int pageNo = 0, int pageSize = 0);
        Task<List<ReviewDTO>> GetReviewsByCustomerId(int customerId, int pageNo = 0, int pageSize = 0);
        Task<List<ReviewDTO>> GetReviewsByProductId(int productId, int pageNo = 0, int pageSize = 0);
        Task<ReviewDTO?> GetReviewById(int id);
    }
}