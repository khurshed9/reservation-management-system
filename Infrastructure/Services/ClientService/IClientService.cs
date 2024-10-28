using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Reservation_Management_System.DTOs;

namespace Reservation_Management_System.Infrastructure.Services.ClientService;

public interface IClientService
{
    PaginationResponse<IEnumerable<ClientReadInfo>> GetClients(ClientFilter filter);
    
    ClientReadInfo? GetClientById(int id);
    
    bool CreateClient(ClientCreateInfo createInfo);
    
    bool UpdateClient(ClientUpdateInfo updateInfo);
    
    bool DeleteClient(int id);
}