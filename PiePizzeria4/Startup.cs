using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PiePizzeria.Data;
using PiePizzeria.Models;

namespace PiePizzeria
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // register my own services

            //services.AddTransient<IPieRepository, MockPieRepository>(); // Transient = Instantiated every time you call it
            services.AddDbContext<PizzaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PizzaContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStatusCodePages(); // 404 Error Code Pages
            app.UseStaticFiles(); // Use wwwroot stuff, bootstrap, etc.

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"
                    );


            });// (routes => { routes.MapRoute(name: null, template: "{controller}/{action}/{id?}"); });
        }
    }
}
