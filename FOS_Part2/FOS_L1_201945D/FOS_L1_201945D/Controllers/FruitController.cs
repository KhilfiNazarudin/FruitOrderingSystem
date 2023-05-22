using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOS_L1_201945D.Models;
using FOS_L1_201945D.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace FOS_L1_201945D.Controllers
{
    [Authorize]
    public class FruitController : Controller
    {
        FruitsOrderDBContext FODBC;
        
        public FruitController(FruitsOrderDBContext context)
        {
            FODBC = context;
        }

        [AllowAnonymous]
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
        public IActionResult Index2()
        {
            ViewBag.Title = "Fruits Page";
            ICollection<Fruit> fruitlist = FODBC.Fruit
                                        //
                                        .Include(Fruit => Fruit.FruitCategory)
                                        .ToList();
            return View(fruitlist);
        }
        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult searchFruits()
        {
            return RedirectToAction("Index");

        }
        [AllowAnonymous]
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
        
        
        
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddFruit()
        {
            FruitVM fvm = new FruitVM();
            fvm.FruitCategories = FODBC.FruitCategory.ToList();
            
            ViewBag.Title = "Add fruits";
            return View(fvm);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddFruit(FruitVM fvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FODBC.Fruit.Add(fvm.Fruit);
                    FODBC.SaveChanges();

                    
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to add the fruit record." +
                    "Please try again, and if the problem persists," +
                    "Please see your system administrator");
            }

            fvm.FruitCategories = FODBC.FruitCategory.ToList();
            return View(fvm);

        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditFruit(int? Id)
        {
            if (Id != null)
            {
                FruitVM fvm = new FruitVM
                {
                    FruitCategories = FODBC.FruitCategory.ToList(),

                    Fruit = (from Fruit in FODBC.Fruit
                             where Fruit.Id == Id
                             select Fruit).Include(bk => bk.FruitCategory).FirstOrDefault()
                };

                return View(fvm);
            }

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditFruit(FruitVM fvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FODBC.Fruit.Update(fvm.Fruit);
                    FODBC.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to edit the fruit record." +
                    "Please try again, and if the problem persists," +
                    "Please see your system administrator");
            }

            fvm.FruitCategories = FODBC.FruitCategory.ToList();
            return View(fvm);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeleteFruit(int? id)
        {
            try
            {
                if (id != null)
                {

                    FruitVM fvm = new FruitVM();
                    fvm.FruitCategories = FODBC.FruitCategory.ToList();

                    fvm.Fruit = (from Fruit in FODBC.Fruit
                                   where Fruit.Id == id
                                   select Fruit).Include(bk => bk.FruitCategory).FirstOrDefault();


                    FODBC.Fruit.Remove(fvm.Fruit);
                    FODBC.SaveChanges();
                    return RedirectToAction("Index");



                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Unable to delete fruit record." +
                    "Please try again, and if the problem persists, " +
                    "Please see your system administrator";
                return View();
            }

            return RedirectToAction("Index2");



        }


    }
}
