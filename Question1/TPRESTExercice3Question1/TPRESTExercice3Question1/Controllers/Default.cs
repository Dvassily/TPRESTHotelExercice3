﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TPRESTExercice3Question1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Default : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hotel1Service works !";
        }
    }
}
