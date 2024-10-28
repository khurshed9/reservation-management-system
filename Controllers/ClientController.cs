using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Microsoft.AspNetCore.Mvc;
using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Services.ClientService;

namespace Reservation_Management_System.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController(IClientService clientService) : ControllerBase
{

    [HttpGet]
    public IActionResult GetClients([FromQuery] ClientFilter filter)
        => Ok(ApiResponse<PaginationResponse<IEnumerable<ClientReadInfo>>>.Success(null, clientService.GetClients(filter)));

    [HttpGet("get/{id}")]
    public IActionResult GetClientById(int id)
    {
        ClientReadInfo? clientById = clientService.GetClientById(id);
        return clientById != null
            ? Ok(ApiResponse<ClientReadInfo?>.Success(null, clientById))
            : NotFound(ApiResponse<ClientReadInfo?>.Fail(null, clientById));
    }

    [HttpPost]
    public IActionResult CreateClient(ClientCreateInfo clientCreateInfo)
    {
        bool clientCreated = clientService.CreateClient(clientCreateInfo);
        return clientCreated
            ? Ok(ApiResponse<bool>.Success(null, clientCreated))
            : BadRequest(ApiResponse<bool>.Fail(null, clientCreated));
    }

    [HttpPut]
    public IActionResult UpdateClient(ClientUpdateInfo clientUpdateInfo)
    {
        bool clientUpdated = clientService.UpdateClient(clientUpdateInfo);
        return clientUpdated
            ? Ok(ApiResponse<bool>.Success(null, clientUpdated))
            : NotFound(ApiResponse<bool>.Fail(null, clientUpdated));
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteClient(int id)
    {
        bool clientDeleted = clientService.DeleteClient(id);
        return clientDeleted
            ? Ok(ApiResponse<bool>.Success(null, clientDeleted))
            : NotFound(ApiResponse<bool>.Fail(null, clientDeleted));
    }
}