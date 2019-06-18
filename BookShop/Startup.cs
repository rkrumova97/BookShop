using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models;
using BookShop.Services;
using LittlePacktBookstore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<BookShopDbContext>(dbContextOptionsBuilder =>
            dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=bookstore;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddScoped<IRepository<Book>, SqlBooksRepository>();
            services.AddScoped<IRepository<Carousel>, SqlCarouselRepository>();
            services.AddScoped<IRepository<Order>, SqlOrderRepository>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseMvc(ConfigureRoutes);
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }


        private static void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapRoute("default", "{controller=Login}/{action=Login}/{id?}");
        }
    }
}
