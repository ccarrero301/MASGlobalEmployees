using System.Collections.Generic;
using System.Threading.Tasks;
using MASGlobal.Employees.Data.Contracts;
using MASGlobal.Employees.Shared.Resources;
using MASGlobal.Employees.Shared.Rest.Contracts;
using MASGlobal.Employees.Shared.Rest.Entities;
using DataEmployeeDto = MASGlobal.Employees.Shared.DTOs.Data.Employee;

namespace MASGlobal.Employees.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IRestClient _restClient;

        public EmployeeRepository(IRestClient restClient) => _restClient = restClient;

        public Task<IEnumerable<DataEmployeeDto>> GetAllEmployeesAsync()
        {
            var employeesEndpointRequest = GetEmployeesEndpointRequest();

            return _restClient.ExecuteGetResultAsync<IEnumerable<DataEmployeeDto>>(employeesEndpointRequest);
        }

        private static RestClientRequest GetEmployeesEndpointRequest() =>
            new RestClientRequest(Rest.ExternalEmployeeBaseUri, Rest.ExternalAllEmployeesResource);
    }
}