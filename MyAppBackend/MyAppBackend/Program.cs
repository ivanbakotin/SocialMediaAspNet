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
    action filter if owner, is not deleted, if friend
    remove comment replace with [removed]
    generic post and comment service for most of service methods
    angular error modal - subscribe
    finish profile, thread
    get 5 users with top number of of posts for recommended people
    pagination - posts 10 by 10 with offset
    fix date on frontend
 */