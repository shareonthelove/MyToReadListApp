using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ToReadList.Data;

namespace ToReadList
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();// BuildWebHost(args);
            //InitializeDatabase(host.Services.CreateScope());
            
            
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

private static void InitializeDatabase(IWebHost host)
{
using (var scope = host.Services.CreateScope())
{
var services = scope.ServiceProvider;
                try
                {
                    SeedData.InitializeAsync(services).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services
                    .GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error occurred seeding the DB.");
                }
            }
}


    }
}
