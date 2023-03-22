using System.ComponentModel.DataAnnotations;

namespace EmployeesApi.Models;

public record HiringRequestCreate
{
    [Required]
    public string FirstName { get; init; } = string.Empty;
    [Required]
    public string LastName { get; init; } = string.Empty;
    [MaxLength(1000)]
    public string? Note { get; init; }

}