namespace EmployeesApi.Models;

public record DepartmentItem
{
    public string Id { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}