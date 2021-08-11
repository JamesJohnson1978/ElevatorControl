using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ElevatorControl
{
    /// <summary>
    /// The ElevatorControl application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ElevatorControl Application Entrypoint
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a host builder
        /// </summary>
        /// <param name="args">arguments passed to run</param>
        /// <returns>An IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
