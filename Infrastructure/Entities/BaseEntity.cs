﻿namespace Reservation_Management_System.Infrastructure.Entities;

public abstract class BasEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
    public DateTime DeletedAt { get; set; } = DateTime.MinValue;
    public bool IsDeleted { get; set; } 
    public long Version { get; set; }
}