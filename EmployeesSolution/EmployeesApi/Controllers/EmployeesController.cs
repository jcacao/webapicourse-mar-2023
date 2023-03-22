﻿
//using EmployeesApi.Controllers.Domain;

namespace EmployeesApi.Controllers;

public class EmployeesController : ControllerBase
{

    private readonly ILookupEmployees _employeeLookupService;

    public EmployeesController(ILookupEmployees employeeLookupService)
    {
        _employeeLookupService = employeeLookupService;
    }



    // GET / employees
    // make URIs CASE SENSITIVE - always do them the same way.
    [HttpGet("/employees")]

    public async Task<ActionResult<EmployeeSummaryResponse>> GetAllEmployees([FromQuery] string dept = "All")
    {
        var response = new EmployeeSummaryResponse(18, 10, 8, dept);
        return Ok(response); // 200 Ok, but serialized this .NET object to the client.
    }

    [HttpGet("/employees/{employeeId}")]
    public async Task<ActionResult<EmployeeResponse>> GetEmployeeById([FromRoute] string employeeId)
    {
        EmployeeResponse? response = await _employeeLookupService.GetEmployeeByIdAsync(employeeId);
        if (response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
    }

    [HttpGet("/employees/{employeeId}/contact-information/home")]
    public async Task<ActionResult<ContactItem>> GetEmployeeHomeContactInfo(string employeeId)
    {
        ContactItem? response = await _employeeLookupService.GetEmployeeContactInfoForHomeAsync(employeeId); return Ok(response);
    }

}
