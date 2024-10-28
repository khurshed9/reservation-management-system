using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Microsoft.AspNetCore.Mvc;
using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;
using Reservation_Management_System.Infrastructure.Services.BookingService;

namespace Reservation_Management_System.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingController(IBookingService bookingService) : ControllerBase
{

    [HttpGet]
    public IActionResult GetBookings([FromQuery] BookingFilter filter)
    {
        var bookings = bookingService.GetBookings(filter);
        return Ok(ApiResponse<PaginationResponse<IEnumerable<BookingReadInfo>>>.Success(null, bookings));
    }

    [HttpGet("{id}")]
    public IActionResult GetBookingById(int id)
    {
        var booking = bookingService.GetBookingById(id);
        return booking != null
            ? Ok(ApiResponse<BookingReadInfo?>.Success(null, booking))
            : NotFound(ApiResponse<BookingReadInfo?>.Fail(null, booking));
    }

    [HttpPost]
    public IActionResult CreateBooking([FromBody] BookingCreateInfo createInfo)
    {
        string message = bookingService.CreateBooking(createInfo);
        return message.Length > 0
           ? BadRequest(ApiResponse<string>.Fail(null, message))
            : Ok(ApiResponse<string>.Success(null, message));
    }

    [HttpPut]
    public IActionResult UpdateBooking([FromBody] BookingUpdateInfo updateInfo)
    {
        bool isUpdated = bookingService.UpdateBooking(updateInfo);
        return isUpdated
            ? Ok(ApiResponse<bool>.Success(null, isUpdated))
            : NotFound(ApiResponse<bool>.Fail(null, isUpdated));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBooking(int id)
    {
        bool isDeleted = bookingService.DeleteBooking(id);
        return isDeleted
            ? Ok(ApiResponse<bool>.Success(null, isDeleted))
            : NotFound(ApiResponse<bool>.Fail(null, isDeleted));
    }
}
