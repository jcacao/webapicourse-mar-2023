namespace EmployeesApi
{
    public interface ILookupEmployees
    {
        Task<EmployeeResponse?> GetEmployeeByIdAsync(string employeeId);
    }
}