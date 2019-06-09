﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MASGlobal.Employees.Shared.DTOs.Services;
using MASGlobal.Employees.Shared.Resources;
using MASGlobal.Employees.Shared.Rest.Contracts;
using MASGlobal.Employees.Shared.Rest.Entities;
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
            var serviceEmployeesDtoList = await GetEmployeesList(employeeId).ConfigureAwait(false);

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

        private async Task<IEnumerable<Employee>> GetEmployeesList(int employeeId)
        {
            var baseUri = Rest.InternalEmployeeBaseUri;
            var allEmployeesResource = Rest.InternalAllEmployeesResource;
            var singleEmployeeResource = Rest.InternalSingleEmployeesResource;

            if (employeeId != int.MinValue)
                return await GetSingleEmployeeList(employeeId, baseUri, singleEmployeeResource).ConfigureAwait(false);

            return await GetAllEmployeesList(baseUri, allEmployeesResource).ConfigureAwait(false);
        }

        private async Task<IEnumerable<Employee>> GetSingleEmployeeList(int employeeId, string baseUri,
            string singleEmployeeResource)
        {
            var employeeIdUrlSegmentDictionary = new Dictionary<string, string>
            {
                {"employeeId", employeeId.ToString()}
            };

            var request = new RestClientRequest(baseUri, singleEmployeeResource, null, null,
                employeeIdUrlSegmentDictionary);

            var serviceEmployeesDto =
                await _restClient.ExecuteGetResultAsync<Employee>(request).ConfigureAwait(false);

            var singleEmployeeList = new List<Employee> {serviceEmployeesDto};

            return singleEmployeeList;
        }

        private async Task<IEnumerable<Employee>> GetAllEmployeesList(string baseUri, string allEmployeesResource)
        {
            var request = new RestClientRequest(baseUri, allEmployeesResource);

            var serviceEmployeesDtoList = await _restClient.ExecuteGetResultAsync<IEnumerable<Employee>>(request)
                .ConfigureAwait(false);

            var allEmployeesList = new List<Employee>();
            allEmployeesList.AddRange(serviceEmployeesDtoList);

            return allEmployeesList;
        }
    }
}