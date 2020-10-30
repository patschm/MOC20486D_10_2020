using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using Repository.InMemory;

using Repository.Interfaces;
using RestService.Configuration;
using RestService.Filters;
using RestService.Formatters;
using RestService.Middleware;

namespace RestService
{
    public class Startup
    {
        private IWebHostEnvironment Environment { get; set; }
        private IConfiguration Configuration { get; set; }

        public Startup(IWebHostEnvironment env, IConfiguration config)
        {
            Environment = env;
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // string data = Configuration.GetSection("MijnData:Hallo").Value;
            //MijnData obj = new MijnData();
            //Configuration.GetSection("MijnData").Bind(obj);
            //Console.WriteLine(obj.Hallo);
            services.Configure<MijnData>(Configuration.GetSection("MijnData"));
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddApplicationInsightsTelemetry(opts => {
                opts.ConnectionString = "InstrumentationKey=bb4b1c2b-c944-4a77-a567-ceb86267f3c6;IngestionEndpoint=https://westeurope-1.in.applicationinsights.azure.com/";
                opts.EnableHeartbeat = true;
            });

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
            app.UseErrorMiddleware();

            //app.UseExceptionHandler(app =>
            //{
            //    app.Run((HttpContext httpContext) =>
            //    {
            //        var data = httpContext.Features.Get<IExceptionHandlerFeature>();
            //        return httpContext.Response.WriteAsync("Hoi");
            //    });
            //});

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
