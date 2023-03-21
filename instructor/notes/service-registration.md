# When Adding Services

## "Lazy Concrete"

"Sometime in the future, Api, You may create something that needs a DepartmentsLookup object. Create one then, and reuse that through that whole request.


```csharp
 builder.Services.AddScoped<DepartmentsLookup>();
 ```


 ## "Lazy Abstract"

 
```csharp
 builder.Services.AddScoped<ILookupDepartments,DepartmentsLookup>();
 ```

 - `ILookupDepartments` is an interface.
 - `DepartmentLookups` is an implementation.
 