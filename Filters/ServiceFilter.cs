using Reservation_Management_System.Infrastructure.Entities;

namespace EmployeeManagement.Filters;

public class ServiceFilter : BaseFilter
{
    public decimal? Price { get; set; }
}