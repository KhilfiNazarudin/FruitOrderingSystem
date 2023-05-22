using FOS_L1_201945D.Models;
using FOS_L1_201945D.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FOS_L1_201945D.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        FruitsOrderDBContext FODBC;

        public OrdersController(FruitsOrderDBContext context)
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
        public IActionResult Ordering()
        {
            OrderDetailsVM ODVM = new OrderDetailsVM();
            ODVM.OrderVM = new OrderVM();
            ODVM.OrderVM.Fruits = FODBC.Fruit.Include(b => b.FruitCategory).ToList();

            return View(ODVM);
        }

        [HttpPost]
        public IActionResult Ordering(OrderDetailsVM ODVM)
        {
            
            ODVM.OrderVM.Fruits = FODBC.Fruit.Include(b => b.FruitCategory).ToList();
            
            decimal tp = 0;
            int var = 0;
            //foreach (var x in ODVM.OrderVM.selected) //EMPTY 
            //{
                foreach(var z in ODVM.OrderVM.Fruits)
                {
                    //if (x.Id == z.Id)
                    //{
                        tp = tp + (z.Price * ODVM.OrderVM.Quantity[var]);
                        var++;
                    //}
                    
                }

            //}
            Order order = new Order
            {
                Address = ODVM.Address,
                ContactNumber = ODVM.ContactNumber,
                Date = ODVM.Date,
                UserName = User.Identity.Name,
                TotalPrice = tp
                
            };
            try
            {
                if (ModelState.IsValid)
                {
                    FODBC.Order.Add(order);
                    FODBC.SaveChanges();

                    var index = 0;
                    foreach (var x in ODVM.OrderVM.Fruits) //EMPTY
                    {
                        var itemVM = ODVM.OrderVM;
                        OrderItem orderItem = new OrderItem
                        {
                            OrderId = (from stuff in FODBC.Order
                                  orderby stuff.Id descending
                                  select stuff.Id).FirstOrDefault(),
                            FruitId = (itemVM.Fruits[index].Id),
                            Quantity = (itemVM.Quantity[index]),
                            SubTotal = itemVM.Fruits[index].Price * itemVM.Quantity[index],
                            //Fruit = itemVM.selected[index],
                            //Order = order
                        };
                        
                        if(orderItem.Quantity > 0)
                        {
                            FODBC.OrderItem.Add(orderItem);
                            FODBC.SaveChanges();
                        }
                        index++;

                    }
                    return RedirectToAction("Index","Fruit");
                }
               
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to add the order record." +
                    "Please try again, and if the problem persists," +
                    "Please see your system administrator");
            }
            return View(ODVM);
        }
    
        [HttpGet]
        public IActionResult orderHistory(string sortParam)
        {
       
            var order = from b in FODBC.Order
                        where b.UserName == User.Identity.Name
                        select b;

            switch (sortParam)
            {
                case "date":
                    order = order.OrderBy(b => b.Date);
                    break;

                case "totalprice":
                    order = order.OrderBy(b => b.TotalPrice);
                    break;

                case "id":
                    order = order.OrderBy(b => b.Id);
                    break;


            }


            return View(order.ToList());
        }

        [HttpPost]
        public IActionResult orderHistory(int id)
        {
            
            var order = from b in FODBC.Order
                        where b.Id == id & b.UserName == User.Identity.Name
                        select b;


            return View(order.ToList());
        }

        [HttpGet]
        public IActionResult viewItems(int? id)
        {

            var orderItems = from b in FODBC.OrderItem.Include(f => f.Fruit).Include(f => f.Fruit.FruitCategory)
                             where b.OrderId == id
                             select b;


            return View(orderItems.ToList());
        }

    }
}
