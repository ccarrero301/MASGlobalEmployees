﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MASGlobal.Employees.WebApi
{
    internal sealed class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}