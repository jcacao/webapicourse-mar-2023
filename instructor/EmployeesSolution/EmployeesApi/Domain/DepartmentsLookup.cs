using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Domain;

public class DepartmentsLookup : ILookupDepartments
{
    private readonly EmployeesDataContext _context;

    public DepartmentsLookup(EmployeesDataContext context)
    {
        _context = context;
    }

    public async Task<List<DepartmentItem>> GetDepartmentsAsync()
    {
        // Never use .Result! Always use the Async version of methods, and await them.

        var response = await _context.Departments
                .Where(dept => dept.Code != "sales")
                .OrderBy(dept => dept.Code)
              .Select(dept => new DepartmentItem(dept.Code, dept.Description))
              
              .ToListAsync();


        return response;

    }
}
