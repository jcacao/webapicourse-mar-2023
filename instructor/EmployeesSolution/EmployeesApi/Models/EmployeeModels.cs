namespace EmployeesApi.Models;

/*
 * {

	"total": 18,
	"fullTime": 10,
	"partTime": 8

}*/

public record EmployeeSummaryResponse(int Total, int FullTime, int PartTime, string DepartmentFilter);

public record EmployeeResponse(string Id, NameInformation NameInformation, WorkDetails WorkDetails, Dictionary<string, Dictionary<string,string>> ContactInformation);

public record NameInformation(string FirstName, string LastName);

public record WorkDetails(string Department);



