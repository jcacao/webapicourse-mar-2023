using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeesApi.Controllers.Domain;
using EmployeesApi.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeesApi.Domain;

public class EntityFrameworkEmployeeLookup : ILookupEmployees, IManageEmployees
{
    private readonly EmployeesDataContext _context;
    private readonly IMapper _mapper;
    private readonly MapperConfiguration _config;
    public EntityFrameworkEmployeeLookup(EmployeesDataContext context, IMapper mapper, MapperConfiguration config)
    {
        _context = context;
        _mapper = mapper;
        _config = config;
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
        return await GetContactInfoAsync<HomeContactItem>(employeeId);

    }
    public async Task<ContactItem?> GetEmployeeContactInfoForWorkAsync(string employeeId)
    {
        return await GetContactInfoAsync<WorkContactItem>(employeeId);
    }

    public async Task<bool> UpdateContactInfoAsync(string employeeId, HomeContactItem contactItem)
    {
        var id = int.Parse(employeeId);
        var employee = await _context.Employees.SingleOrDefaultAsync(emp => emp.Id == id);
        
        if (employee != null)
        {
            employee.HomePhone = contactItem.Phone;
            employee.HomeEmail = contactItem.Email;

            // NOTHING WILL HAPPEN UNLESS YOU DO THIS.
            await _context.SaveChangesAsync();
            return true;
        };
        return false;
    }

    private async Task<ContactItem?> GetContactInfoAsync<TModel>(string employeeId) where TModel : ContactItem
    {
        var id = int.Parse(employeeId);
        var response = await _context.Employees.Where(emp => emp.Id == id)
             .ProjectTo<TModel>(_config)
             .SingleOrDefaultAsync();

        return response;
    }

}

