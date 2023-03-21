using EmployeesApi.Domain;

namespace EmployeesApi.Controllers;

public class DepartmentsController : ControllerBase
{

    private readonly ILookupDepartments _departmentLookup;

    public DepartmentsController(ILookupDepartments departmentLookup)
    {
        _departmentLookup = departmentLookup;
    }

    [HttpGet("/departments")]
    public async Task<ActionResult> GetAllDepartments()
    {
       
        var data = await _departmentLookup.GetDepartmentsAsync();
        var response = new SharedCollectionResponse<DepartmentItem>() { Data = data };
        return Ok(response);
    }
}
