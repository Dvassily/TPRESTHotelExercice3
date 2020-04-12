using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel2Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Default : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hotel2Service works !";
        }
    }
}
