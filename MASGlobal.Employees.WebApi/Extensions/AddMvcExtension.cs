using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;

namespace MASGlobal.Employees.WebApi.Extensions
{
    internal static class AddMvcExtension
    {
        public static void AddMvcService(this IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options => { options.SerializerSettings.Converters.Add(new StringEnumConverter()); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}