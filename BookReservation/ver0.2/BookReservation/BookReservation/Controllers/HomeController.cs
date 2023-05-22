using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReservation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return Content("This is a book reservation project PROJECT VERSION 0.1");
            return View();

            //PROJECT VERSION 0.1
        }
    }
}
