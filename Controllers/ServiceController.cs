using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Services.ServiceService;

namespace Reservation_Management_System.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/services")]
public class ServiceController(ISerService services) : ControllerBase
{
    
    [HttpGet]
    public IActionResult GetServices([FromQuery] ServiceFilter filter)
    {
        var response = services.GetServices(filter);
        return Ok(ApiResponse<PaginationResponse<IEnumerable<ServiceReadInfo>>>.Success(null, response));
    }

    [HttpGet("get/{id}")]
    public IActionResult GetServiceById(int id)
    {
        ServiceReadInfo? service = services.GetServiceById(id);
        return service != null
            ? Ok(ApiResponse<ServiceReadInfo?>.Success(null, service))
            : NotFound(ApiResponse<ServiceReadInfo?>.Fail(null, null));
    }

    [HttpPost]
    public IActionResult CreateService(ServiceCreateInfo serviceCreateInfo)
    {
        var result = services.CreateService(serviceCreateInfo);
        return result
            ? Ok(ApiResponse<bool>.Success(null, result))
            : BadRequest(ApiResponse<bool>.Fail(null, result));
    }

    [HttpPut]
    public IActionResult UpdateService(ServiceUpdateInfo serviceUpdateInfo)
    {
        var result = services.UpdateService(serviceUpdateInfo);
        return result
            ? Ok(ApiResponse<bool>.Success(null, result))
            : NotFound(ApiResponse<bool>.Fail(null, result));
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteService(int id)
    {
        var result = services.DeleteService(id);
        return result
            ? Ok(ApiResponse<bool>.Success(null, result))
            : NotFound(ApiResponse<bool>.Fail(null, result));
    }
}
