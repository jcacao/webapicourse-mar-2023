namespace EmployeesApi.Domain;

public class DepartmentsLookup
{

    public async Task<List<DepartmentItem>> GetDepartmentsAsync()
    {
        // TODO: Tomorrow, this will get data from out database.

        return new List<DepartmentItem>
       {
           new DepartmentItem("DEV", "Developers"),
           new DepartmentItem("QA", "Quality Assurance Analysts"),
           new DepartmentItem("SALES", "Sales Engineers")
       };

    }
}
