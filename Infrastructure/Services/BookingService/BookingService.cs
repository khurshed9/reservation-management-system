using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Microsoft.EntityFrameworkCore;
using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;
using Reservation_Management_System.Mapper;

namespace Reservation_Management_System.Infrastructure.Services.BookingService;

public class BookingService(DataContext context) : IBookingService
{

    public PaginationResponse<IEnumerable<BookingReadInfo>> GetBookings(BookingFilter filter)
    {
        IQueryable<Booking> bookings = context.Bookings;
        
        if (filter.Status != null)
        {
            bookings = context.Bookings.Where(b => b.Client.MembershipLevel == filter.Status);
        }
        
        IQueryable<BookingReadInfo> res = bookings.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize)
            .Select(b => b.BookingToReadInfo()); 

        int totalRecords = context.Bookings.Count();

        return PaginationResponse<IEnumerable<BookingReadInfo>>.Create(filter.PageNumber, filter.PageSize, totalRecords, res);
    }

    public BookingReadInfo? GetBookingById(int id)
    {
        BookingReadInfo? booking = context.Bookings
            .Where(b => b.Id == id)
            .Select(b => b.BookingToReadInfo())
            .FirstOrDefault();

        return booking;
    }

    public string CreateBooking(BookingCreateInfo createInfo)
    {
        bool isOverlap = context.Bookings.Any(x =>
            x.BookingFrom < createInfo.BookingTo && createInfo.BookingFrom < x.BookingTo
        );

        if (isOverlap)
        {
            return "This time has already been booked. Please choose another.";
        }

        context.Bookings.Add(createInfo.CreateInfoToBooking());
    
        if (context.SaveChanges() > 0)
        {
            return "The reservation has been successfully created.";
        }

        return "An error occurred while creating the reservation.";
    }

    public bool UpdateBooking(BookingUpdateInfo updateInfo)
    {
        Booking? booking = context.Bookings.FirstOrDefault(b =>b.IsDeleted == false && b.Id == updateInfo.Id);
        if (booking == null) return false;

        context.Bookings.Update(booking.UpdateInfoToBooking(updateInfo));
        return context.SaveChanges() > 0;
    }

    public bool DeleteBooking(int id)
    {
        Booking? booking = context.Bookings.FirstOrDefault(b =>b.IsDeleted == false && b.Id == id);
        if (booking == null) return false;

        context.Bookings.Remove(booking.DeleteInfoToBooking());
        return context.SaveChanges() > 0;
    }
}
