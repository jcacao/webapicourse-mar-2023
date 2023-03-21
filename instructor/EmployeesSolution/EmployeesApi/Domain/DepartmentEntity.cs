namespace EmployeesApi.Domain;

public class DepartmentEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty; // "DEV", "QA"
    public string Description { get; set;} = string.Empty;
}
