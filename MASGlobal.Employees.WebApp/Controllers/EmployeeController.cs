using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MASGlobal.Employees.DTOs.Services;
using MASGlobal.Employees.Rest.Contracts;
using MASGlobal.Employees.Rest.Entities;
using MASGlobal.Employees.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MASGlobal.Employees.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRestClient _restClient;

        public EmployeeController(IRestClient restClient) => _restClient = restClient;

        public IActionResult Home() => View();

        [HttpGet]
        public IActionResult GetEmployees(int employeeId = int.MinValue)
        {
            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = employeeId,
                Employees = new List<Employee>()
            };

            return View("Index", employeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployeesPost(int employeeId = int.MinValue)
        {
            var allEmployeesEndpointRequest = GetAllEmployeesEndpointRequest();
            var serviceEmployeesDto = await _restClient.ExecuteGetResultAsync<IEnumerable<Employee>>(allEmployeesEndpointRequest).ConfigureAwait(false);

            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = employeeId,
                Employees = serviceEmployeesDto
            };

            return View("Index", employeeViewModel);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

        private static RestClientRequest GetAllEmployeesEndpointRequest() =>
            new RestClientRequest("localhost:44344/api/", "Employee/all");
    }
}