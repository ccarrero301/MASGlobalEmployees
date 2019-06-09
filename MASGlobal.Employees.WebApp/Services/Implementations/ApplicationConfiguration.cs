using MASGlobal.Employees.WebApp.Services.Contracts;
using Microsoft.Extensions.Configuration;

namespace MASGlobal.Employees.WebApp.Services.Implementations
{
    internal class ApplicationConfiguration : IApplicationConfiguration
    {
        private readonly IConfiguration _configuration;

        public ApplicationConfiguration(IConfiguration configuration) => _configuration = configuration;

        public string EmployeesApiBaseUri => GetConfiguration("EmployeesApi", "BaseUri");

        public string EmployeesApiAllEmployeesResource => GetConfiguration("EmployeesApi", "AllEmployeesResource");

        public string EmployeesApiSingleEmployeeResource => GetConfiguration("EmployeesApi", "SingleEmployeeResource");

        private string GetConfiguration(string key, string value) => _configuration[$"{key}:{value}"];
    }
}