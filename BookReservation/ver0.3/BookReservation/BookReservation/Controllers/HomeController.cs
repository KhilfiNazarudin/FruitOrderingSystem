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
            // return Content("This is the BookReservation Project");
            return View();
        }

        public IActionResult BookReservation()
        {
            // return Content("This is the BookReservation Project");
            ViewBag.Title = "This is Book Reservation";
            return View();
        }

        public IActionResult Index2()
        {
            ViewBag.Title = "This is Index 2";
            return View();
        }
    }
}
