using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MyAppBackend
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
                    webBuilder.UseStartup<Startup>();
                });
    }
}

/*
    loading frontend on start
    store in session ask user remember me
    comments as tree
    google auth
    fix jwt always the same
    seperate admin panel
    action filter validation
    angular error modal
    angular wait for cookie to be set
    generic post and comment service for most of service methods
    pagination
 */