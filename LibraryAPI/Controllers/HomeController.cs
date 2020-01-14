using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public object Index()
        {
            return new { name = "LibraryAPI" };
            }
    }
}
