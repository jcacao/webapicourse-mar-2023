using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeesApi.Domain;

public class EntityFrameworkEmployeeLookup : ILookupEmployees
{
    private readonly EmployeesDataContext _context;

    public EntityFrameworkEmployeeLookup(EmployeesDataContext context)
    {
        _context = context;
    }

    public async Task<EmployeeResponse?> GetEmployeeByIdAsync(string employeeId)
    {
        var id = int.Parse(employeeId);

        var employee = await _context.Employees
            .Where(e => e.Id == id)
            .SingleOrDefaultAsync(); // this will return 0 or 1, if it returns mroe than 1 BLOW UP


        if (employee is null) { return null; }

        return new EmployeeResponse(employee.Id.ToString(), new NameInformation(employee.FirstName, employee.LastName), new WorkDetails(employee.Department),
                new Dictionary<string, Dictionary<string, string>>
                {
                                    { "home", new Dictionary<string, string> { { "email", employee.HomeEmail}, { "phone", employee.HomePhone } } },
                                    { "work", new Dictionary<string, string> {{ "email", employee.WorkEmail}, {  "phone", employee.WorkPhone } } },
                }
            );
    }

}

