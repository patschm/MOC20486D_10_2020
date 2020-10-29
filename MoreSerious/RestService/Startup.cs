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

namespace RestService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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
