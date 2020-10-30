using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    [Route("error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok("Ooops");
        }
    }
}
