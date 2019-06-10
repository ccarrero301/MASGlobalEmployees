using MASGlobal.Employees.Shared.Rest.Contracts;
using MASGlobal.Employees.Shared.Rest.Implementations;
using MASGlobal.Employees.WebApp.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace MASGlobal.Employees.WebApp.Extensions
{
    public static class AddServicesExtension
    {
        public static void AddDependencyInjectionServices(this IServiceCollection services, IApplicationConfiguration applicationConfiguration)
        {
            services.AddSingleton(applicationConfiguration);

            services.AddScoped<IRestClient, RestClient>();
        }
    }
}