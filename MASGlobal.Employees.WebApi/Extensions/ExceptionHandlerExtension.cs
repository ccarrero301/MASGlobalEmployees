using System;
using System.Threading.Tasks;
using GlobalExceptionHandler.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MASGlobal.Employees.WebApi.Extensions
{
    public static class ExceptionHandlerExtension
    {
        internal static void UseCustomExceptionHandler(this IApplicationBuilder applicationBuilder) =>
            HandleGeneralExceptionErrors(applicationBuilder);

        private static void HandleGeneralExceptionErrors(IApplicationBuilder app)
        {
            app.UseGlobalExceptionHandler(x =>
            {
                x.ContentType = "application/json";
                x.ResponseBody(s => JsonConvert.SerializeObject(new
                {
                    Message = "This is the general error"
                }));

                x.Map<Exception>().ToStatusCode(StatusCodes.Status500InternalServerError)
                    .WithBody((ex, context) => ex.Message);

                x.OnError((exception, httpContext) => Task.CompletedTask);
            });
        }
    }
}