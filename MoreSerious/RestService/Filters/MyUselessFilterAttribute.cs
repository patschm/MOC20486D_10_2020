using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestService.Filters
{
    public class MyUselessFilterAttribute : ActionFilterAttribute
    {
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Ervoor");
            //await context.HttpContext.Response.WriteAsync("Ervoor");
            base.OnActionExecuting(context);
        }
        public override async void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Erna");
            //await context.HttpContext.Response.WriteAsync("Erna");
            base.OnActionExecuted(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Voor result");
            base.OnResultExecuting(context);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("End result");
            base.OnResultExecuted(context);
        }
    }
}
