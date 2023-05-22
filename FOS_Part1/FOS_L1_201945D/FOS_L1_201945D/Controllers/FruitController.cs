using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOS_L1_201945D.Models;
using FOS_L1_201945D.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FOS_L1_201945D.Controllers
{
    public class FruitController : Controller
    {
        FruitsOrderDBContext FODBC;
        
        public FruitController(FruitsOrderDBContext context)
        {
            FODBC = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Fruits Page";
            ICollection<Fruit> fruitlist = FODBC.Fruit
                                         //
                                        .Include(Fruit => Fruit.FruitCategory)
                                        .ToList();
            return View(fruitlist);
        }

        [HttpGet]
        public IActionResult searchFruits()
        {
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult searchFruits(string category)
        {
            ViewBag.Title = "Search Fruits";

            searchFruitsByCat searchedCategory = new searchFruitsByCat();

           
            searchedCategory.searchedTerm = category;
            searchedCategory.CategoryList = (from cat in FODBC.FruitCategory
                                             where cat.Name.Contains(category)
                                             select cat)
                                             .ToList();
            searchedCategory.FruitList = FODBC.Fruit.Include(b => b.FruitCategory).ToList();

            

            return View(searchedCategory);
            
            
        }

        public IActionResult AddFruit()
        {
            ViewBag.Title = "Add fruits";
            return View();
        }
    }
}
