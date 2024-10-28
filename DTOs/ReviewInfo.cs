namespace Reservation_Management_System.DTOs;

public readonly record struct ReviewReadInfo(
    int Id,
    int Rating,
    string Comments,
    DateTime Date);
    
    
public readonly record struct ReviewCreateInfo(
    int Rating,
    string Comments,
    DateTime Date);
    
    
public readonly record struct ReviewUpdateInfo(
    int Id,
    int Rating,
    string Comments,
    DateTime Date);