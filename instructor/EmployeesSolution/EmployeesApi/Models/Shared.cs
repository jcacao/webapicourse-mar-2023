namespace EmployeesApi.Models;


public class SharedCollectionResponse<T>
{
    public List<T> Data { get; init; } = new List<T>();
}
