using System.Text.Json.Serialization;

namespace EmployeesApi.Domain;

public class DepartmentEntity
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonPropertyName("id")]
    public string Code { get; set; } = string.Empty; // "DEV", "QA"
    public string Description { get; set;} = string.Empty;
}
