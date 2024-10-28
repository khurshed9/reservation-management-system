using Reservation_Management_System.Infrastructure.Enums;

namespace Reservation_Management_System.Infrastructure.Entities;

public class Client : BasEntity
{
    public string FullName { get; set; } = null!;

    public string ContractNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public ClientMembershipLevel MembershipLevel { get; set; }
    
    public IEnumerable<Service> Services { get; set; } = [];
    
    public IEnumerable<Booking> BookingHistory { get; set; } = [];

}