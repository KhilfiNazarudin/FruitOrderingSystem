using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FOS_L1_201945D.Models;
using Microsoft.EntityFrameworkCore;
using FOS_L1_201945D.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FOS_L1_201945D.Controllers
{
    [Authorize]
    public class FruitCategoryController : Controller
    {

        FruitsOrderDBContext FODBC;

        public FruitCategoryController(FruitsOrderDBContext context)
        {
            FODBC = context;

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Fruit Categories";
            ICollection<FruitCategory> fruitCategoryList = FODBC.FruitCategory.ToList();
            return View(fruitCategoryList);
        }

        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult searchFruitCategory()
        {

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddCategory()
        {
            
            ViewBag.Title = "Add Category";
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCategory(FruitCategory nfc)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    FruitCategory fc = new FruitCategory(nfc.Name, nfc.Description);
                    
                    FODBC.FruitCategory.Add(fc);
                    FODBC.SaveChanges();


                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to add the category record." +
                    "Please try again, and if the problem persists," +
                    "Please see your system administrator");
            }

            return View(nfc);

        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditCategory(int? Id)
        {
            if (Id != null)
            {
                FruitCategory fc = new FruitCategory();

                fc.Name = (from FruitCategory in FODBC.FruitCategory
                             where FruitCategory.Id == Id
                             select FruitCategory.Name).FirstOrDefault();

                fc.Description = (from FruitCategory in FODBC.FruitCategory
                                    where FruitCategory.Id == Id
                                    select FruitCategory.Description).FirstOrDefault();

                return View(fc);
            }

            return RedirectToAction("Index");



        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditCategory(FruitCategory fc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FruitCategory nfc = new FruitCategory(fc.Id, fc.Name, fc.Description);

                    FODBC.FruitCategory.Update(nfc);
                    FODBC.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to edit the category record." +
                    "Please try again, and if the problem persists," +
                    "Please see your system administrator");
            }

            return View(fc);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeleteCategory(int? id)
        {
            try
            {
                if (id != null)
                {
                    FruitCategory fc = new FruitCategory();

                    fc = (from Category in FODBC.FruitCategory
                                 where Category.Id == id
                                 select Category).FirstOrDefault();


                    FODBC.FruitCategory.Remove(fc);
                    FODBC.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Unable to delete category record." +
                    "Please try again, and if the problem persists, " +
                    "Please see your system administrator";
                return View();
            }

            return RedirectToAction("Index");



        }
    }
}
