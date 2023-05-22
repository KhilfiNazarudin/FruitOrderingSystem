using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FOS_L1_201945D.Models;
using Microsoft.EntityFrameworkCore;

namespace FOS_L1_201945D.Controllers
{
    public class FruitCategoryController : Controller
    {

        FruitsOrderDBContext FODBC;

        public FruitCategoryController(FruitsOrderDBContext context)
        {
            FODBC = context;

        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Fruit Categories";
            ICollection<FruitCategory> fruitCategoryList = FODBC.FruitCategory.ToList();
            return View(fruitCategoryList);
        }

        [HttpPost]
        public IActionResult searchFruitCategory(String category)
        {
            ViewBag.Title = "Search Categories";
            //Returns a list of categories
            var fruitCategoryList = (from FruitCategory in FODBC.FruitCategory
                                     where FruitCategory.Name.Contains(category)
                                     select FruitCategory).ToList();
            return View(fruitCategoryList);
        }
        [HttpGet]
        public IActionResult searchFruitCategory()
        {

            return RedirectToAction("Index");
        }

        public IActionResult AddCategory()
        {
            ViewBag.Title = "Add category";

            return View();
        }
    }
}
