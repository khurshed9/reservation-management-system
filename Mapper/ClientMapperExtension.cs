using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;

namespace Reservation_Management_System.Mapper;

public static class ClientMapperExtension
{
    public static ClientReadInfo ClientToReadInfo(this Client client)
    {
        return new ClientReadInfo
        {
            Id = client.Id,
            FullName = client.FullName,
            ContractNumber = client.ContractNumber,
            EmailAddress = client.EmailAddress,
            MembershipLevel = client.MembershipLevel
        };
    }

    public static Client UpdateInfoToClient(this Client client, ClientUpdateInfo updateInfo)
    {
        client.FullName = updateInfo.FullName;
        client.ContractNumber = updateInfo.ContractNumber;
        client.EmailAddress = updateInfo.EmailAddress;
        client.MembershipLevel = updateInfo.MembershipLevel;
        return client;
    }

    public static Client CreateInfoToClient(this ClientCreateInfo createInfo)
    {
        return new Client
        {
            FullName = createInfo.FullName,
            ContractNumber = createInfo.ContractNumber,
            EmailAddress = createInfo.EmailAddress,
            MembershipLevel = createInfo.MembershipLevel
        };
    }

    public static Client DeleteInfoToClient(this Client deleteInfo)
    {
        deleteInfo.IsDeleted = true;
        deleteInfo.DeletedAt = DateTime.UtcNow;
        deleteInfo.Version += 1;
        deleteInfo.UpdatedAt = DateTime.UtcNow;
        return deleteInfo;
    }
}
