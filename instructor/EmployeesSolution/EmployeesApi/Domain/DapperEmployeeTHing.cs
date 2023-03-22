namespace EmployeesApi.Domain
{
    public class DapperEmployeeTHing : ILookupEmployees
    {
        public Task<EmployeeResponse?> GetEmployeeByIdAsync(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactItem?> GetEmployeeContactInfoForHomeAsync(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactItem?> GetEmployeeContactInfoForWorkAsync(string employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
