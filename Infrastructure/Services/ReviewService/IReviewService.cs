using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Reservation_Management_System.DTOs;

namespace Reservation_Management_System.Infrastructure.Services.ReviewService;

public interface IReviewService
{
    PaginationResponse<IEnumerable<ReviewReadInfo>> GetReviews(ReviewFilter filter);
    
    ReviewReadInfo? GetReviewById(int id);
    
    bool CreateReview(ReviewCreateInfo createInfo);

    bool UpdateReview(ReviewUpdateInfo updateInfo);

    bool DeleteReview(int id);
}