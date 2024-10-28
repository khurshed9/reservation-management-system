namespace Reservation_Management_System.Infrastructure.Entities;

public class Master : BasEntity
{
    public string FullName { get; set; } = null!;

    public string Specialty  { get; set; } = null!;
    
    public int ExperienceYears { get; set; }

    public Dictionary<string, string> Availability { get; set; } = [];

    public IEnumerable<Service> Services { get; set; } = [];

    public IEnumerable<Booking> UpcomingBookings { get; set; } = [];

}