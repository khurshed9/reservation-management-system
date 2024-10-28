using Reservation_Management_System.Infrastructure.Entities;
using Reservation_Management_System.Infrastructure.Enums;

namespace EmployeeManagement.Filters;

public class BookingFilter : BaseFilter
{
    public ClientMembershipLevel? Status { get; set; }
}