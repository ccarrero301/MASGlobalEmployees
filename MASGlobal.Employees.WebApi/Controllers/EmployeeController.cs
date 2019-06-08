using System.Threading.Tasks;
using MASGlobal.Employees.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MASGlobal.Employees.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetEmployees()
        {
            var serviceDtoEmployees = await _employeeService.GetEmployeesAsync().ConfigureAwait(false);

            return Ok(serviceDtoEmployees);
        }
    }
}