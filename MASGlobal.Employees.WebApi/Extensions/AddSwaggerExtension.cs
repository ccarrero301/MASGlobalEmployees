using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace MASGlobal.Employees.WebApi.Extensions
{
    internal static class AddSwaggerExtension
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Employees Web API",
                    Version = "v1",
                    Description = "API to manage employees"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.CustomSchemaIds(type => type.FullName);
            });
        }
    }
}