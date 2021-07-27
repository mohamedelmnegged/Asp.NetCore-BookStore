using BookStore.Models;
using BookStore.Models.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore ;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class Startup
    {
        //this property to get to the configuartion file
        public IConfiguration Configuration; 

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //injection code to add the classes in the project 
            services.AddMvc();
            services.AddScoped<IBooksRepo<Book>, BookDbRepo>(); 
            services.AddScoped<IBooksRepo<Author>, AuthorDbRepo>();

            //add the connection to database 
            services.AddDbContext<BookStoreDBContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("SQLconnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                //endpoints.MapGet("/", async context =>
                //{
                //   // await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
