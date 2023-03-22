# Employees

Joe - an employee at our company
Sue - manager at the company

## `GET /employees/{employeeId}`

```json
{
    "employeeId": "A1",
    "nameInformation": {
        "firstName": "Jeff",
        "lastName": "Gonzalez"
    },
    "workDetails": {
        "department": "DEV"
    }
}
```

[Authorize("Managers")]
## `GET /employees/{employeeId}/contact-information`

```json
{
        "home": {
            "email": "jeff@aol.com",
            "phone": "555-1212"
        },
        "work": {
            "email": "jeff@company.com",
            "phone": "888-1212"
        }
}
```

[Authorize("Managers")]
## `GET /employees/{employeeId}/contact-information/home`

```json

     {
            "email": "jeff@aol.com",
            "phone": "555-1212"
        }
        

```

[Authorize("Employees, Managers")]
## `GET /employees/{employeeId}/contact-information/work`

```json

     {
            "email": "jeff@company.com",
            "phone": "888-1212"
        }
        

```