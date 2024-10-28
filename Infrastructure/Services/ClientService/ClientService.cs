using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;
using Reservation_Management_System.Mapper;

namespace Reservation_Management_System.Infrastructure.Services.ClientService;

public class ClientService(DataContext context) : IClientService
{

    public PaginationResponse<IEnumerable<ClientReadInfo>> GetClients(ClientFilter filter)
    {
        IQueryable<Client> clients = context.Clients;
        if (filter.FullName != null)
            clients = context.Clients.Where(x =>
                x.IsDeleted == false && x.FullName.ToLower() == filter.FullName.ToLower());

        IQueryable<ClientReadInfo> res = clients.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize)
            .Select(x => x.ClientToReadInfo());

        int totalRecords = context.Clients.Count(x => x.IsDeleted == false);

        return PaginationResponse<IEnumerable<ClientReadInfo>>.Create(filter.PageNumber, filter.PageSize, totalRecords, res);
    }

    public ClientReadInfo? GetClientById(int id)
    {
        ClientReadInfo? client = context.Clients
            .Where(x => x.IsDeleted == false && x.Id == id)
            .Select(x => x.ClientToReadInfo())
            .FirstOrDefault();

        return client;
    }

    public bool CreateClient(ClientCreateInfo createInfo)
    {
        context.Clients.Add(createInfo.CreateInfoToClient());
        return context.SaveChanges() > 0;
    }

    public bool UpdateClient(ClientUpdateInfo updateInfo)
    {
        Client? client = context.Clients
            .FirstOrDefault(x => x.IsDeleted == false && x.Id == updateInfo.Id);
        if (client == null) return false;

        context.Clients.Update(client.UpdateInfoToClient(updateInfo));
        return context.SaveChanges() > 0;
    }

    public bool DeleteClient(int id)
    {
        Client? client = context.Clients
            .FirstOrDefault(x => x.IsDeleted == false && x.Id == id);
        if (client == null) return false;

        context.Clients.Remove(client.DeleteInfoToClient());
        return context.SaveChanges() > 0;
    }
}
