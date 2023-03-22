using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeesApi.Domain;

public class EntityFrameworkEmployeeLookup: ILookupEmployees
{
    private readonly EmployeesDataContext _context;
    private readonly IMapper _mapper;

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

        return _mapper.Map<EmployeeResponse>(employee);
    }

    public async Task<ContactItem?> GetEmployeeContactInfoForHomeAsync(string employeeId)
    {
        var id = int.Parse(employeeId);
        var response = await _context.Employees.Where(emp => emp.Id == id)
        .Select(emp => new ContactItem { Email = emp.HomeEmail, Phone = emp.HomePhone })
        .SingleOrDefaultAsync(); return response;
    }
}
