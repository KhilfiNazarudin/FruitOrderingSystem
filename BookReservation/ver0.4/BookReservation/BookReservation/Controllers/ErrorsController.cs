using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReservation.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("/Errors")]
        public IActionResult Index()
        {
            ViewBag.Title = "Error";
            return View();
        }

        public IActionResult HttpError(string id)
        {
            ViewBag.Title = "HTTP Error";

            return View();
        }
    }
}
