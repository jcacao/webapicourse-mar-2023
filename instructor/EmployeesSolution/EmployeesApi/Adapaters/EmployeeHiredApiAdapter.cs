namespace EmployeesApi.Adapaters;

public class EmployeeHiredApiAdapter
{
    private readonly HttpClient _httpClient;

    public EmployeeHiredApiAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task NotifyOfNewHire(string email, DateTime hireDate)
    {
        var request = new EmployeeHiringRequest(email, hireDate);
        var response = await _httpClient.PostAsJsonAsync("/hiring-notifications", request);

        response.EnsureSuccessStatusCode();

    }
}

public record EmployeeHiringRequest(string email, DateTime hireDate);