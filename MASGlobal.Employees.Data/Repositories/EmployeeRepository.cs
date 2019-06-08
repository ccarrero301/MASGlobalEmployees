using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MASGlobal.Employees.Data.Contracts;
using MASGlobal.Employees.Domain;
using MASGlobal.Employees.Rest.Contracts;
using MASGlobal.Employees.Rest.Entities;

namespace MASGlobal.Employees.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IRestClient _restClient;

        public EmployeeRepository(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employeesEndpointRequest = GetEmployeesEndpointRequest();

            return _restClient.ExecuteGetResultAsync<IEnumerable<Employee>>(employeesEndpointRequest);
        }

        public Task<Employee> GetEmployeesById(int employeeId)
        {
            throw new NotImplementedException();
        }

        private static RestClientRequest GetEmployeesEndpointRequest() =>
            new RestClientRequest("", "", null, null, null, null);
    }
}