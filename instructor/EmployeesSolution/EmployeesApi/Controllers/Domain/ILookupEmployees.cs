namespace EmployeesApi
{
    public interface ILookupEmployees
    {
        Task<EmployeeResponse?> GetEmployeeByIdAsync(string employeeId);
        Task<ContactItem?> GetEmployeeContactInfoForHomeAsync(string employeeId);
        Task<ContactItem?> GetEmployeeContactInfoForWorkAsync(string employeeId);
    }
}