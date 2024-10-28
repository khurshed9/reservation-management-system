using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;

namespace Reservation_Management_System.Mapper;

public static class BookingMapperExtension
{
    
    public static BookingReadInfo BookingToReadInfo(this Booking booking)
    {
        return new BookingReadInfo
        {
            Id = booking.Id,
            ClientId = booking.ClientId,
            MasterId = booking.MasterId,
            ServiceId = booking.ServiceId,
            BookingFrom = booking.BookingFrom,
            BookingTo = booking.BookingTo,
            Status = booking.Status,
            Notes = booking.Notes,
            AppointmentDate = booking.AppointmentDate
        };
    }

    public static Booking UpdateInfoToBooking(this Booking booking, BookingUpdateInfo updateInfo)
    {
        booking.ClientId = updateInfo.ClientId;
        booking.MasterId = updateInfo.MasterId;
        booking.ServiceId = updateInfo.ServiceId;
        booking.BookingFrom = updateInfo.BookingFrom;
        booking.BookingTo = updateInfo.BookingTo;
        booking.Status = updateInfo.Status;
        booking.Notes = updateInfo.Notes;
        booking.AppointmentDate = updateInfo.AppointmentDate;
        return booking;
    }

    public static Booking CreateInfoToBooking(this BookingCreateInfo createInfo)
    {
        return new Booking
        {
            ClientId = createInfo.ClientId,
            MasterId = createInfo.MasterId,
            ServiceId = createInfo.ServiceId,
            BookingFrom = createInfo.BookingFrom,
            BookingTo = createInfo.BookingTo,
            Status = createInfo.Status,
            Notes = createInfo.Notes,
            AppointmentDate = createInfo.AppointmentDate,
        };
    }

    public static Booking DeleteInfoToBooking(this Booking deleteInfo)
    {
        deleteInfo.IsDeleted = true;
        deleteInfo.DeletedAt = DateTime.UtcNow;
        deleteInfo.Version += 1;
        deleteInfo.UpdatedAt = DateTime.UtcNow;
        return deleteInfo;
    }
}
