using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Reservation_Management_System.DTOs;

namespace Reservation_Management_System.Infrastructure.Services.ServiceService;

public interface ISerService
{
    PaginationResponse<IEnumerable<ServiceReadInfo>> GetServices(ServiceFilter filter);
    
    ServiceReadInfo? GetServiceById(int id);
    
    bool CreateService(ServiceCreateInfo createInfo);

    bool UpdateService(ServiceUpdateInfo updateInfo);

    bool DeleteService(int id);
}