using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MASGlobal.Employees.Shared.Resources;
using MASGlobal.Employees.Shared.Rest.Contracts;
using MASGlobal.Employees.Shared.Rest.Entities;
using MASGlobal.Employees.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceEmployeeDto = MASGlobal.Employees.Shared.DTOs.Services.Employee;

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
                Employees = new List<ServiceEmployeeDto>()
            };

            return View("Index", employeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployeesPost(int employeeId = int.MinValue)
        {
            var serviceEmployeesDtoList = await GetServiceEmployeeDtoList(employeeId).ConfigureAwait(false);

            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = employeeId,
                Employees = serviceEmployeesDtoList
            };

            return View("Index", employeeViewModel);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel
            {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

        private async Task<IEnumerable<ServiceEmployeeDto>> GetServiceEmployeeDtoList(int employeeId)
        {
            var baseUri = Rest.InternalEmployeeBaseUri;
            var allEmployeesResource = Rest.InternalAllEmployeesResource;
            var singleEmployeeResource = Rest.InternalSingleEmployeesResource;

            if (employeeId == int.MinValue)
                return await GetAllServiceEmployeeDtoList(baseUri, allEmployeesResource).ConfigureAwait(false);

            var singleServiceEmployee = await GetSingleServiceEmployeeDto(employeeId, baseUri, singleEmployeeResource)
                .ConfigureAwait(false);
            return new List<ServiceEmployeeDto> {singleServiceEmployee};
        }

        private Task<ServiceEmployeeDto> GetSingleServiceEmployeeDto(int employeeId,
            string baseUri, string singleEmployeeResource)
        {
            var employeeIdUrlSegmentDictionary = new Dictionary<string, string>
            {
                {"employeeId", employeeId.ToString()}
            };

            var restClientRequest = new RestClientRequest(baseUri, singleEmployeeResource, null, null,
                employeeIdUrlSegmentDictionary);

            return _restClient.ExecuteGetResultAsync<ServiceEmployeeDto>(restClientRequest);
        }

        private Task<IEnumerable<ServiceEmployeeDto>> GetAllServiceEmployeeDtoList(string baseUri,
            string allEmployeesResource)
        {
            var restClientRequest = new RestClientRequest(baseUri, allEmployeesResource);

            return _restClient.ExecuteGetResultAsync<IEnumerable<ServiceEmployeeDto>>(restClientRequest);
        }
    }
}