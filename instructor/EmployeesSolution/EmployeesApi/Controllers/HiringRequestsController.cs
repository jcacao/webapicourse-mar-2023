using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Controllers;

public class HiringRequestsController : ControllerBase
{
    private readonly EmployeesDataContext _context;

    public HiringRequestsController(EmployeesDataContext context)
    {
        _context = context;
    }
    // only the hiring manager can do this.
    [HttpPost("/departments/{department}/employees")]
    public async Task<ActionResult> HireEmployee([FromBody] HiringRequestEntity request, [FromRoute] string department)
    {
        var storedRequest = await _context.HiringRequests.SingleOrDefaultAsync(r => r.Id == request.Id && request.Status == HiringRequestStatus.PendingDepartment);
        var storedDepartment = await _context.Departments.SingleOrDefaultAsync(d => d.Code == department);

        if(storedRequest == null || storedDepartment == null)
        {
            return NotFound();
        } else
        {
            var newEmployee = new EmployeeEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Department = department,

            };
            storedRequest.Status = HiringRequestStatus.Approved;
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return NoContent(); // or the employee, or whatever.
        }



    }

    [HttpPost("/hiring-requests")]
    [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 10)]
    public async Task<ActionResult> AddHiringRequest([FromBody] HiringRequestCreate request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }
        var hiringEntity = new HiringRequestEntity
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Note = request.Note ?? "",
            CreatedAt = DateTime.UtcNow,
            Status = HiringRequestStatus.PendingDepartment
        };
        _context.HiringRequests.Add(hiringEntity);
        await _context.SaveChangesAsync();
        // A post to a collection should return a 201 Created, a Link to the new item, and a copy of that item.
        // http://localhost:1338/hiring-requests/4
        // http://api.company.com/v2/hiring-request/18
        return CreatedAtRoute("hiringrequests-get-by-id", new { id = hiringEntity.Id }, hiringEntity);
    }

    [ResponseCache(Location = ResponseCacheLocation.Any, Duration =10)]
    [HttpGet("/hiring-requests/{id:int}", Name ="hiringrequests-get-by-id")]
    public async Task<ActionResult> GetHiringRequest([FromRoute] int id)
    {
        var response = await _context.HiringRequests.SingleOrDefaultAsync(r => r.Id == id);
        return response is null ? NotFound() : Ok(response);
    }
}
