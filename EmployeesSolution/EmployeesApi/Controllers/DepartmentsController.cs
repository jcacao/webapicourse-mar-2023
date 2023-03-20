namespace EmployeesApi.Controllers
{
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentsLookup _departmentLookup;

        public DepartmentsController(DepartmentsLookup departmentsLookup)
        {
            _departmentLookup = departmentsLookup;
        }

        
        [HttpGet("/departments")]
        public async Task<ActionResult <SharedCollectionResponse<DepartmentItem>>> GetAllDepartments()
        //public async Task<ActionResult> GetAllDepartments()
        {
            //var service = new DepartmentsLookup(); //DON'T DO THIS
            var data  = await _departmentLookup.GetDepartmentsAsync();
            var response = new SharedCollectionResponse<DepartmentItem>() { Data = data };
            return Ok(response);
        }
    }
}
