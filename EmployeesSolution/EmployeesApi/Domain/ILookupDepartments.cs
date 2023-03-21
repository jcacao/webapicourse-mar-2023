namespace EmployeesApi.Domain
{
    public interface ILookupDepartments
    {
        Task<List<DepartmentItem>> GetDepartmentsAsync();
    }
}