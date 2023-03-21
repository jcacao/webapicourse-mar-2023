namespace EmployeesApi.Domain;

public class FakeDepartmentLookup : ILookupDepartments
{
    public async Task<List<DepartmentItem>> GetDepartmentsAsync()
    {
        return new List<DepartmentItem>() { new DepartmentItem("CEO", "Running THings") };
    }
}
