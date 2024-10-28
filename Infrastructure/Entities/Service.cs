namespace Reservation_Management_System.Infrastructure.Entities;

public class Service : BasEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Duration { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;
}