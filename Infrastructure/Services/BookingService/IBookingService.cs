using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Reservation_Management_System.DTOs;

namespace Reservation_Management_System.Infrastructure.Services.BookingService;

public interface IBookingService
{
    
    PaginationResponse<IEnumerable<BookingReadInfo>> GetBookings(BookingFilter filter);
    
    BookingReadInfo? GetBookingById(int id);
    
    string CreateBooking(BookingCreateInfo createInfo);
    
    bool UpdateBooking(BookingUpdateInfo updateInfo);
    
    bool DeleteBooking(int id);
}