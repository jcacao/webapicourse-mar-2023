namespace EmployeesApi.Controllers.Domain
{
    public interface ILookupEmployees
    {
        Task<EmployeeResponse?> GetEmployeeByIdAsync(string employeeId);
    }
}