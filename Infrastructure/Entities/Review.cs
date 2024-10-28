namespace Reservation_Management_System.Infrastructure.Entities;

public class Review : BasEntity
{
    public Client Client { get; set; }

    public Master Master { get; set; }

    public int Rating { get; set; }

    public string Comments { get; set; } = null!;

    public DateTime Date { get; set; }
}