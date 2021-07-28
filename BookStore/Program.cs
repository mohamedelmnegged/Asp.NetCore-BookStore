using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var WebHost = CreateHostBuilder(args).Build();
            // after build the app create the migraion 

          //  CreateMigration(WebHost);
            // run the application 
            WebHost.Run();
        }

        //this method call database to create migraion 
        private static void CreateMigration(IHost webHost)
        {
           using(var scope = webHost.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BookStoreDBContext>();
                db.Database.Migrate(); 
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
