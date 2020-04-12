using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Agence2Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Default : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Agence2Service works !";
        }
    }
}
