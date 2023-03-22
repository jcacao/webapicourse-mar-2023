using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Controllers;

public class Departments2Controller : ControllerBase
{
    // NOTE: This isn't the "Pro" way to do this stuff.

    private readonly EmployeesDataContext _context;

    public Departments2Controller(EmployeesDataContext context)
    {
        _context = context;
    }

    [HttpGet("/departments2")]
    public async Task<ActionResult> GetDepartments()
    {
        // Anti-Pattern - returning entity objects (Domain objects)
        var response = await _context.Departments.OrderBy(d => d.Code).ToListAsync();
        return Ok(response);
    }
}
