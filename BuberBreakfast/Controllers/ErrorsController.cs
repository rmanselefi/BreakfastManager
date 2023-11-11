using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuberBreakfast.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("/error")]

        public IActionResult Error(){
            return Problem();
        }
    }
}