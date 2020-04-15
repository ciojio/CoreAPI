using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Core3Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        // Set properties and call methods on options
                    })
                    .UseUrls("http://*:5000")
                    .UseStartup<Startup>();
                });
    }
}