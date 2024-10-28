using Reservation_Management_System.Infrastructure.Enums;

namespace Reservation_Management_System.DTOs;

public readonly record struct BookingReadInfo(
    int Id,
    int ClientId,
    int MasterId,
    int ServiceId,
    DateTime BookingFrom,
    DateTime BookingTo,
    BookStatus Status,
    string Notes,
    DateTime AppointmentDate);
    
    
public readonly record struct BookingCreateInfo(
    int ClientId,
    int MasterId,
    int ServiceId,
    DateTime BookingFrom,
    DateTime BookingTo,
    BookStatus Status,
    string Notes,
    DateTime AppointmentDate);
    
    
public readonly record struct BookingUpdateInfo(
    int Id,
    int ClientId,
    int MasterId,
    int ServiceId,
    DateTime BookingFrom,
    DateTime BookingTo,
    BookStatus Status,
    string Notes,
    DateTime AppointmentDate);