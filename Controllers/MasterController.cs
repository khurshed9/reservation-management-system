using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Microsoft.AspNetCore.Mvc;
using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Services.MasterService;

namespace Reservation_Management_System.Controllers;

[ApiController]
[Route("api/masters")]

public class MasterController(IMasterService masterService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetMasters([FromQuery] MasterFilter filter)
        => Ok(ApiResponse<PaginationResponse<IEnumerable<MasterReadInfo>>>.Success(null, masterService.GetMasters(filter)));

    [HttpGet("get/{id}")]
    public IActionResult GetMasterById(int id)
    {
        MasterReadInfo? masterById = masterService.GetMasterById(id);
        return masterById != null
            ? Ok(ApiResponse<MasterReadInfo?>.Success(null, masterById))
            : NotFound(ApiResponse<MasterReadInfo?>.Fail(null, masterById));
    }

    [HttpPost]
    public IActionResult CreateMaster(MasterCreateInfo masterCreateInfo)
    {
        bool master = masterService.CreateMaster(masterCreateInfo);
        return master
            ? Ok(ApiResponse<bool>.Success(null, master))
            : NotFound(ApiResponse<bool>.Fail(null, master));
    }

    [HttpPut]
    public IActionResult UpdateMaster(MasterUpdateInfo masterUpdateInfo)
    {
        bool master = masterService.UpdateMaster(masterUpdateInfo);
        return master
            ? Ok(ApiResponse<bool>.Success(null, master))
            : NotFound(ApiResponse<bool>.Fail(null, master));
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteMaster(int id)
    {
        bool master = masterService.DeleteMaster(id);
        return master
            ? Ok(ApiResponse<bool>.Success(null, master))
            : NotFound(ApiResponse<bool>.Fail(null, master));
    }
}