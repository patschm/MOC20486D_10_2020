using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestService.Formatters
{
    public class CsvOutFormatter : TextOutputFormatter
    {
        public CsvOutFormatter()
        {
            this.SupportedMediaTypes.Add("text/csv");
            this.SupportedEncodings.Add(Encoding.UTF8);
        }
        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context.Object is Person)
            {
                Person p = context.Object as Person;
                await context.HttpContext.Response.WriteAsync($"{p.ID},{p.FirstName},{p.LastName},{p.Age}\r\n");
            }
            if (context.Object is List<Person>)
            {
                var list = context.Object as List<Person>;
                foreach(var p in list)
                {
                    await context.HttpContext.Response.WriteAsync($"{p.ID},{p.FirstName},{p.LastName},{p.Age}\r\n");
                }
            }
        }
    }
}
