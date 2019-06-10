using System;
using System.Threading.Tasks;
using MASGlobal.Employees.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MASGlobal.Employees.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetEmployees()
        {
            var serviceDtoEmployeeList = await _employeeService.GetAllEmployeesAsync().ConfigureAwait(false);

            return Ok(serviceDtoEmployeeList);
        }

        [HttpGet]
        [Route("{employeeId}")]
        public async Task<ActionResult> GetEmployeeById(int employeeId)
        {
            try
            {
                var serviceDtoEmployee =
                    await _employeeService.GetSingleEmployeeByIdAsync(employeeId).ConfigureAwait(false);

                return Ok(serviceDtoEmployee);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}