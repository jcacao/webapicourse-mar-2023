using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeesApi.Adapters;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Domain
{
    public class DepartmentsLookup : ILookupDepartments
    {
        private readonly EmployeesDataContext _context;
        private readonly MapperConfiguration _config;

        public DepartmentsLookup(EmployeesDataContext context, MapperConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<List<DepartmentItem>> GetDepartmentsAsync()
        {
            var response = await _context.Departments
                    .Where(dept => dept.Code != "sales")
                    .OrderBy(dept => dept.Code)
                //.Select(dept => new DepartmentItem(dept.Code, dept.Description))
                .ProjectTo<DepartmentItem>(_config)
                .ToListAsync();

            return response;
        }
    }
}
