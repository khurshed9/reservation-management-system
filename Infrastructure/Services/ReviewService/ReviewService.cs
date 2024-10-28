using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;
using Reservation_Management_System.Mapper;

namespace Reservation_Management_System.Infrastructure.Services.ReviewService;

public class ReviewService(DataContext context) : IReviewService
{

    public PaginationResponse<IEnumerable<ReviewReadInfo>> GetReviews(ReviewFilter filter)
    {
        IQueryable<Review> reviews = context.Reviews;

        if (filter.Date != null)
            reviews = context.Reviews.Where(x => x.IsDeleted == false && x.Date == filter.Date);
        
        var totalRecords = reviews.Count();
        var paginatedReviews = reviews.Skip((filter.PageNumber - 1) * filter.PageSize)
                                      .Take(filter.PageSize)
                                      .Select(r => r.ReviewToReviewInfo());

        return PaginationResponse<IEnumerable<ReviewReadInfo>>.Create(filter.PageNumber, filter.PageSize, totalRecords, paginatedReviews);
    }

    public ReviewReadInfo? GetReviewById(int id)
    {
        return context.Reviews
            .Where(r => !r.IsDeleted && r.Id == id)
            .Select(r => r.ReviewToReviewInfo())
            .FirstOrDefault();
    }

    public bool CreateReview(ReviewCreateInfo createInfo)
    {
        context.Reviews.Add(createInfo.CreateInfoToReview());
        return context.SaveChanges() > 0;
    }

    public bool UpdateReview(ReviewUpdateInfo updateInfo)
    {
        Review? review = context.Reviews.FirstOrDefault(r => !r.IsDeleted && r.Id == updateInfo.Id);
        if (review == null) return false;
        
        context.Reviews.Update(review.UpdateInfoToReview(updateInfo));
        return context.SaveChanges() > 0;
    }

    public bool DeleteReview(int id)
    {
        var review = context.Reviews.FirstOrDefault(r => !r.IsDeleted && r.Id == id);
        if (review == null) return false;

        context.Reviews.Remove(review.DeleteInfoToReview());
        return context.SaveChanges() > 0;
    }
}
