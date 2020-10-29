using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using Repository.InMemory;

using Repository.Interfaces;
using RestService.Filters;
using RestService.Formatters;

namespace RestService
{
    public class Startup
    {
        private IWebHostEnvironment Environment { get; set; }

        public Startup(IWebHostEnvironment env)
        {
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddTransient<IPersonRepository, PersonRepository>();
            }
            services.AddControllers(opts=> {
                opts.OutputFormatters.Add(new CsvOutFormatter());       
                //opts.Filters.Add<MyUselessFilterAttribute>()
            }).AddNewtonsoftJson();
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.Map("/ha", app2 =>
            //{

            //    app2.Run((HttpContext httpContext) =>
            //    {
            //        return httpContext.Response.WriteAsync("hoi run");
            //    });
            //});

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("default", "mijn/route/{id}", defaults: new
                //{
                //    controller = "Person",
                //    action = "Get",
                //    id=0
                //}, 
                //constraints:new { 
                //    id="/d"
                //});
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
