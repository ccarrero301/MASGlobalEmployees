using Microsoft.AspNetCore.Builder;

namespace MASGlobal.Employees.WebApi.Extensions
{
    internal static class ConfigureSwaggerExtension
    {
        public static void AddSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Employees Web API");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}