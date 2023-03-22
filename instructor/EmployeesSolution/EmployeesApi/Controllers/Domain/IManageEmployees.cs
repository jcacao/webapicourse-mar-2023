namespace EmployeesApi.Controllers.Domain;

public interface IManageEmployees
{
    Task<bool> UpdateContactInfoAsync(string employeeId, HomeContactItem contactItem);
}
