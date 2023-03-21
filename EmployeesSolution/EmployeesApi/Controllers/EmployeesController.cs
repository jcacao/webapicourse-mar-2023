
namespace EmployeesApi.Controllers;

public class EmployeesController : ControllerBase
{
    // GET / employees

    [HttpGet("/employees")]

    public async Task<ActionResult<EmployeeSummaryResponse>> GetAllEmployee([FromQuery] string dept = "All")
    {
        var response = new EmployeeSummaryResponse(18, 10, 8, dept);
        return Ok(response); // 200 Ok, but serialized this .NET object to the client.
    }

    [HttpGet("/employees/{employeeId}")]
    public async Task<ActionResult<EmployeeResponse>> GetEmployeeById([FromRoute] string employeeId)
    {
        EmployeeResponse? response = _employeeLookupService.GetEmployeeByIdAsync(employeeId);
        if (response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
        // 200 Ok with that employee
        // 404
    }
}
