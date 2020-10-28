using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataHost.MiddleWare;
using DataHost.SomeClasses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DataHost
{
    public class Startup
    {
        // In deze functie registreer je de services in de DI
        public void ConfigureServices(IServiceCollection services)
        {
            // 1 instantie voor de hele applicatie
            //services.AddSingleton<ICalculator, Calculator>();

            // Per sessie 1 object
            //services.AddScoped<ICalculator, Calculator>();
            // Per Call 1 object
            services.AddTransient<ICalculator, Calculator>();
            //services.AddTransient<ICalculator, SuperCalculator>();

            services.AddControllers();
        }

        // Knutsel hier jouw request pipeline in elkaar
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMiddleware<MyMiddleware>();
            app.UseMyMiddleware();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
