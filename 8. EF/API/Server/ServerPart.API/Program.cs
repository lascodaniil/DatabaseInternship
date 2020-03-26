using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ServerPart.API
{
    public class Program
    {
            public static void Main(string[] args)
            {
                CreateWebHostBuilder(args).Build().Run();
            }

            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>();
        


        //public static IWebHost CreateWebHostBuilder(string[] args)
        //{
        //    return new WebHostBuilder()
        //        .UseKestrel()
        //        .UseUrls("http://localhost:57880 ")
        //        .UseContentRoot(Directory.GetCurrentDirectory())
        //        .ConfigureAppConfiguration((hosting, config) =>
        //        {
        //            config.AddJsonFile("appsettings.json",
        //                optional: true, reloadOnChange: true);
        //            config.AddEnvironmentVariables();
        //            if (args != null)
        //            {
        //                config.AddCommandLine(args);
        //            }
        //        })
        //        .ConfigureLogging((hostingContext, logging) =>
        //        {
        //            logging.AddConfiguration(
        //             hostingContext.Configuration.GetSection("Logging"));
        //            logging.AddConsole();
        //            logging.AddDebug();
        //        })
        //             .UseIISIntegration()
        //             .UseStartup<Startup>()
        //             .Build();
        //}

    }
}
