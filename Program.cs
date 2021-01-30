using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLiabrary.API
{
    public class Program
    {
        // starting point of the application
        // below method is responsible for configuring and running the app
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // In our case we created a web app that requires a host, and that is what is created
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Uses startup class as startup type
                    webBuilder.UseStartup<Startup>();
                });
    }
}
