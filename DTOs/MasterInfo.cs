namespace Reservation_Management_System.DTOs;

public readonly record struct MasterReadInfo(
    int Id,
    string FullName,
    string Specialty,
    int ExperienceYears,
    Dictionary<string,string> Availability);
    
    
public readonly record struct MasterCreateInfo(
    string FullName,
    string Specialty,
    int ExperienceYears,
    Dictionary<string,string> Availability);
    
    
public readonly record struct MasterUpdateInfo(
    int Id,
    string FullName,
    string Specialty,
    int ExperienceYears,
    Dictionary<string,string> Availability);