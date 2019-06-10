using MASGlobal.Employees.Data.Contracts;
using MASGlobal.Employees.Data.Repositories;
using MASGlobal.Employees.Services.Contracts;
using MASGlobal.Employees.Services.Implementations;
using MASGlobal.Employees.Shared.Rest.Contracts;
using MASGlobal.Employees.Shared.Rest.Implementations;
using MASGlobal.Employees.WebApi.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace MASGlobal.Employees.WebApi.Extensions
{
    public static class AddServicesExtension
    {
        public static void AddDependencyInjectionServices(this IServiceCollection services)
        {
            var mapper = MappingConfiguration.Configure();

            services.AddSingleton(mapper);

            services.AddScoped<IRestClient, RestClient>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}