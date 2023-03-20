# Employees API

## Vectors of Functionality

- Resources
    - Identified through URIs


Example: 

`https://api.hypertheory.com/v2/api/employees`

- SCHEME: `https://` 
    - HTTP
    - HTTPS - "Transport Layer Security" (TLS)"
        - Certificates
            - Identity
            - Encryption
- Authority (server): api.hypertheory.com
    - FQDN - 
    
- Path to the Resource
    - v2/api/employees

Resources:
    - the important things.
    - they have a fixed set of possible behaviors.
    - GET/ POST/ PUT/ DELETE (98%) (HEAD, OPTIONS (CORS))



GET /employees

GET /heroes/1

Stuff that varies:
    - URL (GET /employees/bob-smith, GET /employees/jill-jones) => Route Parameters
    - Query String Arguments - GET /employees?department=DEV
    - Headers
        - HTTP Has a set of headers for messages
            - Some headers are valid for both request and response messages (Message Headers)
            - Requests  - Request Headers
            - Responses - Response Headers


GET /employees/567

{
    "id": 567,
    "name": "Bob Smith",
    "phone": "555-1212",
    "email": "bob@aol.com"
}


GET /employes/12
GET /employees/567/manager

{
    "id": 12,
    "name": "Jill Jones",
    "phone": "555-1212",
    "email": "jill@aol.com"
}

