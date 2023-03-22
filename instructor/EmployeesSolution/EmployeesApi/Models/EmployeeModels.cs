using System.ComponentModel.DataAnnotations;

namespace EmployeesApi.Models;

/*
 * {

	"total": 18,
	"fullTime": 10,
	"partTime": 8

}*/

public record EmployeeSummaryResponse(int Total, int FullTime, int PartTime, string DepartmentFilter);

public record EmployeeResponse
{
	public string EmployeeId { get; init; } = string.Empty;
	public NameInformation NameInformation { get; init; } = new();
	public WorkDetails WorkDetails { get; init; } = new();
	
}

public record NameInformation
{
	public string FirstName { get; init; } = string.Empty;
	public string LastName { get; init; } = string.Empty;
}

public record WorkDetails
{
	public string Department { get; init; } = string.Empty;
}

public record ContactItem
{

	[EmailAddress]
	public string Email { get; init; } = string.Empty;

	[Required, MaxLength(200), MinLength(8)]
	public string Phone { get; init; } = string.Empty;
}

public record WorkContactItem : ContactItem;

public record HomeContactItem: ContactItem;