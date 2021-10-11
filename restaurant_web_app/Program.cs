using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace restaurant_web_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //try
                //{
                //    var context = services.GetRequiredService<ApplicationDbContext>();
                //    IConfiguration configuration = services.GetService<IConfiguration>();

                    
                //    ApplicationDbContextSeed.SeedSampleData(context,50);
                //}
                //catch (Exception ex)
                //{
                //    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                //    logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                //    throw;
                //}
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
