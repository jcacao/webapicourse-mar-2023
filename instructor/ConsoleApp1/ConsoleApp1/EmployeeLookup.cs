

namespace ConsoleApp1;

public class EmployeeLookup
{
    public Employee? GetEmployeeById(int id)
    {
       if(id % 2 == 0)
        {
            return new Employee(id, "Bob Smith", 50000);
        } else
        {
            return null;
        }
    }
}

//public record Employee(int Id, string Name, decimal Salary)
//{
//    public Employee GiveRaise(Employee employee, decimal amount)
//    {
//        return employee with { Salary = employee.Salary + amount };
//    }
//}

public record Employee
{
    public required int Id { get; init; }
    public required string Name { get; init; } = string.Empty;
    public decimal Salary { get; init; }
}


//public class Employee

//{
//    public Employee(int id, string name, decimal salary)
//    {
//        Id = id;
//        Name = name;
//        Salary = salary;
//    }

//    public int Id { get; private set; }
//    public string Name { get; private set; }
//    public decimal Salary { get; private set; }
//}