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
    comments as tree
    google auth
    seperate admin panel
    action filter checkifowner, isnotdeleted 
    remove comment replace with [removed]
    angular error modal
    generic post and comment service for most of service methods
    pagination
    forbid non friends seeing your posts, friends etc
    fix date on frontend
 */