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
    comments as tree -- last
    loading frontend on start - during check is loggedin
    google auth
    seperate admin panel
    remove comment replace with [removed] if tree
    pagination - posts 10 by 10 with offset - infinite scroll - angular library not updated
    fix dates
    email server smtp
    make everything async backend
    tags/hashtags on posts
    implement groups
    if owner, if friend
 */