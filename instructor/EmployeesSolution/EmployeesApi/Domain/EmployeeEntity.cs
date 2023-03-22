namespace EmployeesApi.Domain;

public class EmployeeEntity
{
    public int Id { get; set; } // Entity Framework will by CONVENTION the PK, AutoNumber (1, 2, 3)
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set;} = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string HomePhone { get; set; } = string.Empty;
    public string HomeEmail { get; set;} = string.Empty;    
    public string WorkPhone { get; set;} = string.Empty;    
    public string WorkEmail { get; set; } = string.Empty;

  
}


/*
 * {
    "id": "2",
    "nameInformation": {
        "firstName": "Bob",
        "lastName": "Smith"
    },
    "workDetails": {
        "department": "DEV"
    },
    "contactInformation": {
        "home": {
            "email": "bob@aol.com",
            "phone": "555-1212"
        },
        "work": {
            "email": "bob@company.com",
            "phone": "888-1212"
        }
    }
}*/