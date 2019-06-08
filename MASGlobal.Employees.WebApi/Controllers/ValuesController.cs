using System.Threading.Tasks;
using MASGlobal.Employees.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MASGlobal.Employees.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetEmployees()
        {
            var employees = await _repository.GetAllEmployeesAsync().ConfigureAwait(false);

            return Ok(employees);
        }
    }
}