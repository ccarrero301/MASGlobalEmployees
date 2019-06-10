using MASGlobal.Employees.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MASGlobal.Employees.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjectionServices();

            services.AddSwaggerService();

            services.AddMvcService();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHsts();

            app.AddSwaggerMiddleware();

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}