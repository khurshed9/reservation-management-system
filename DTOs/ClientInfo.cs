using Reservation_Management_System.Infrastructure.Enums;

namespace Reservation_Management_System.DTOs;

public readonly record struct ClientReadInfo(
    int Id,
    string FullName,
    string ContractNumber,
    string EmailAddress,
    ClientMembershipLevel MembershipLevel);
    
    
public readonly record struct ClientCreateInfo(
    string FullName,
    string ContractNumber,
    string EmailAddress,
    ClientMembershipLevel MembershipLevel);
    
    
public readonly record struct ClientUpdateInfo(
    int Id,
    string FullName,
    string ContractNumber,
    string EmailAddress,
    ClientMembershipLevel MembershipLevel);