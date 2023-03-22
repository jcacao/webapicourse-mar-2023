using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Domain;

public enum HiringRequestStatus { PendingDepartment, Denied, Approved}
public class HiringRequestEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string Note { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    [Precision(18,2)]
    public decimal ProposedSalary { get; set; }

    public HiringRequestStatus Status { get; set; }

}
