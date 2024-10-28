namespace Reservation_Management_System.DTOs;

public readonly record struct ServiceReadInfo(
    int Id,
    string Name,
    string Description,
    int Duration,
    decimal Price,
    string Category);


public readonly record struct ServiceCreateInfo(
    string Name,
    string Description,
    int Duration,
    decimal Price,
    string Category);


public readonly record struct ServiceUpdateInfo(
    int Id,
    string Name,
    string Description,
    int Duration,
    decimal Price,
    string Category);
