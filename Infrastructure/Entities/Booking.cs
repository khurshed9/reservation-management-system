using Reservation_Management_System.Infrastructure.Enums;

namespace Reservation_Management_System.Infrastructure.Entities;

public class Booking : BasEntity
{
    public BookStatus Status { get; set; }

    public string Notes { get; set; } = null!;

    public DateTime BookingFrom { get; set; }

    public DateTime BookingTo { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public int MasterId { get; set; }
    public Master Master { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    public DateTime AppointmentDate  { get; set; }
    
}