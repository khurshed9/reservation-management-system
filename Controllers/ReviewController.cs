using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Microsoft.AspNetCore.Mvc;
using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Services.ReviewService;

namespace Reservation_Management_System.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewController(IReviewService reviewService) : ControllerBase
{

    [HttpGet]
    public IActionResult GetReviews([FromQuery] ReviewFilter filter)
    {
        var response = reviewService.GetReviews(filter);
        return Ok(ApiResponse<PaginationResponse<IEnumerable<ReviewReadInfo>>>.Success(null, response));
    }

    [HttpGet("{id}")]
    public IActionResult GetReviewById(int id)
    {
        var review = reviewService.GetReviewById(id);
        return review != null
            ? Ok(ApiResponse<ReviewReadInfo?>.Success(null, review))
            : NotFound(ApiResponse<ReviewReadInfo?>.Fail(null, review));
    }

    [HttpPost]
    public IActionResult CreateReview([FromBody] ReviewCreateInfo createInfo)
    {
        var success = reviewService.CreateReview(createInfo);
        return success
            ? Ok(ApiResponse<bool>.Success(null, success))
            : BadRequest(ApiResponse<bool>.Fail(null, success));
    }

    [HttpPut]
    public IActionResult UpdateReview([FromBody] ReviewUpdateInfo updateInfo)
    {
        var success = reviewService.UpdateReview(updateInfo);
        return success
            ? Ok(ApiResponse<bool>.Success(null, success))
            : NotFound(ApiResponse<bool>.Fail(null, success));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReview(int id)
    {
        var success = reviewService.DeleteReview(id);
        return success
            ? Ok(ApiResponse<bool>.Success(null, success))
            : NotFound(ApiResponse<bool>.Fail(null, success));
    }
}
