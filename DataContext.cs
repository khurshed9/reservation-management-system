using Microsoft.EntityFrameworkCore;
using Reservation_Management_System.Infrastructure.Entities;

namespace Reservation_Management_System;

public class DataContext : DbContext
{
    public DbSet<Master> Masters { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Service> Services { get; set; }

    public DbSet<Booking> Bookings { get; set; }

    public DbSet<Review> Reviews { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }
}