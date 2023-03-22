

using EmployeesApi.Controllers.Domain;
using Microsoft.AspNetCore.Authorization;

namespace EmployeesApi.Controllers;

public class EmployeesController : ControllerBase
{

    private readonly ILookupEmployees _employeeLookupService;
    private readonly IManageEmployees _employeeManager;

    public EmployeesController(ILookupEmployees employeeLookupService, IManageEmployees employeeManager)
    {
        _employeeLookupService = employeeLookupService;
        _employeeManager = employeeManager;
    }




    // PUT /employees/1/contact-information/home
    [HttpPut("/employees/{employeeId}/contact-information/home")]
    public async Task<ActionResult> UpdateHomeContactInformation([FromRoute] string employeeId, [FromBody] HomeContactItem contactItem)
    {
        // TODO: Authn 
        
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        // Make sure it passed the validation first.
      
        bool foundAndUpated = await _employeeManager.UpdateContactInfoAsync(employeeId, contactItem);
        return foundAndUpated ? Ok(contactItem) : NotFound();
    }

    // GET /employees/{employeeId}/contact-information
    // TODO: Your Homework

    // GET /employees/{employeeId}/contact-information/home
    [HttpGet("/employees/{employeeId}/contact-information/home")]
    public async Task<ActionResult<ContactItem>> GetEmployeeHomeContactInfo(string employeeId)
    {
        ContactItem? response = await _employeeLookupService.GetEmployeeContactInfoForHomeAsync(employeeId);

        return response is null ? NotFound() : Ok(response);
    }
    // GET /employees/{employeeId}/contact-information/work
    [HttpGet("/employees/{employeeId}/contact-information/work")]
    public async Task<ActionResult<ContactItem>> GetEmployeeWorkContactInfo(string employeeId)
    {
        

        ContactItem? response = await _employeeLookupService.GetEmployeeContactInfoForWorkAsync(employeeId);

        return response is null ? NotFound() : Ok(response);
    }
    // GET /employees
    // make URIs CASE SENSITIVE - always do them the same way.
    [HttpGet("/employees")]
    public async Task<ActionResult<EmployeeSummaryResponse>> GetAllEmployees([FromQuery] string dept = "All")
    {
        var response = new EmployeeSummaryResponse(18, 10, 8, dept);
        return Ok(response); // 200 Ok, but serialize this .NET object to client.

    }

    [HttpGet("/employees/{employeeId}")]
    public async Task<ActionResult<EmployeeResponse>> GetEmployeeById([FromRoute] string employeeId)
    {
        EmployeeResponse? response =await  _employeeLookupService.GetEmployeeByIdAsync(employeeId);
        
        if(response is null)
        {
            return NotFound();
        } else
        {
            return Ok(response);
        }

    }
}
