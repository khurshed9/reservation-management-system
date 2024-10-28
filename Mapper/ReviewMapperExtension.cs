using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;

namespace Reservation_Management_System.Mapper;

public static class ReviewMapperExtension
{

    public static ReviewReadInfo ReviewToReviewInfo(this Review review)
    {
        return new ReviewReadInfo
        {
            Id = review.Id,
            Rating = review.Rating,
            Comments = review.Comments,
            Date = review.Date
        };
    }

    public static Review UpdateInfoToReview(this Review review, ReviewUpdateInfo updateInfo)
    {
        review.Id = updateInfo.Id;
        review.Rating = updateInfo.Rating;
        review.Comments = updateInfo.Comments;
        review.Date = updateInfo.Date;
        return review;
    }

    public static Review CreateInfoToReview(this ReviewCreateInfo createInfo)
    {
        return new Review
        {
            Rating = createInfo.Rating,
            Comments = createInfo.Comments,
            Date = createInfo.Date
        };
    }

    public static Review DeleteInfoToReview(this Review deleteInfo)
    {
        deleteInfo.IsDeleted = true;
        deleteInfo.DeletedAt = DateTime.UtcNow;
        deleteInfo.Version += 1;
        deleteInfo.UpdatedAt = DateTime.UtcNow;
        return deleteInfo;
    }
}
