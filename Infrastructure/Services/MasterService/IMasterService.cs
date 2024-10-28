using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Reservation_Management_System.DTOs;

namespace Reservation_Management_System.Infrastructure.Services.MasterService;

public interface IMasterService
{
    PaginationResponse<IEnumerable<MasterReadInfo>> GetMasters(MasterFilter filter);
    
    MasterReadInfo? GetMasterById(int id);
    
    bool CreateMaster(MasterCreateInfo createInfo);
    
    bool UpdateMaster(MasterUpdateInfo updateInfo);
    
    bool DeleteMaster(int id);
}