namespace EmployeesApi.Models;

public record DepartmentItem
{
    public string Id { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

}

// public record DepartmentItem(string Id, string Description); // "Constructor Record"
// var x = new DepartmentItem("DEV", "Developers");
// var x = new DepartmentItem { Id="DEV", Description="Developers" }
