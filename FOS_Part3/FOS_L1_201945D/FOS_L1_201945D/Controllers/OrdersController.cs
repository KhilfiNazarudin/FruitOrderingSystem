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
        public IActionResult Ordering(int? id)
        {
            if(id != null)
            {
                List<int> takenFruits = (from ORDERS in FODBC.OrderItem
                                         where ORDERS.OrderId == id
                                         select ORDERS.FruitId).ToList();
                OrderVM ovm = new OrderVM
                {
                    order = (from ORDERS in FODBC.Order
                             where ORDERS.Id == id
                             select ORDERS).FirstOrDefault(),
                    //Fruits = FODBC.Fruit.ToList(),
                    Fruits = (  from fruits in FODBC.Fruit
                                where !(from ORDERS in FODBC.OrderItem
                                        where ORDERS.OrderId == id
                                        select ORDERS.FruitId)
                                        .Contains(fruits.Id)
                                select fruits).ToList()
                    

                };
                return View(ovm);

            }
            OrderVM OVM = new OrderVM
            {
                Fruits = FODBC.Fruit.Include(b => b.FruitCategory).ToList()
            };
            
            return View(OVM);
        }

        [HttpPost]
        public IActionResult Ordering(OrderVM OVM)
        {
            Items item = new Items
            {
                Fruit = (from fruit in FODBC.Fruit
                         where fruit.Id == OVM.SelectedFruitId
                         select fruit).Include(cat => cat.FruitCategory).FirstOrDefault(),
                Quantity = OVM.quantity
            };

            decimal tp = 0;
            if (OVM.orderID == 0)
            {
                Debug.WriteLine("first");
                tp = item.Fruit.Price * item.Quantity;
                //CREATES ORDER
                Order order = new Order
                {
                    Address = OVM.Address,
                    ContactNumber = OVM.ContactNumber,
                    Date = OVM.Date,
                    UserName = User.Identity.Name,
                    TotalPrice = tp

                };
                if (ModelState.IsValid)
                {
                    FODBC.Order.Add(order);
                    FODBC.SaveChanges();

                    OrderItem orderItem = new OrderItem
                    {
                        OrderId = (from stuff in FODBC.Order
                                   orderby stuff.Id descending
                                   select stuff.Id).FirstOrDefault(),
                        FruitId = (item.Fruit.Id),
                        Quantity = (item.Quantity),
                        SubTotal = (item.Fruit.Price * item.Quantity),


                    };
                    if (item.Quantity != 0)
                    {
                        FODBC.OrderItem.Add(orderItem);
                        FODBC.SaveChanges();

                    }


                }
                OVM.orderID = (from stuff in FODBC.Order
                               orderby stuff.Id descending
                               select stuff.Id).FirstOrDefault();
                OVM.Fruits = FODBC.Fruit.Include(b => b.FruitCategory).ToList();
                return RedirectToAction("Ordering", new { id = OVM.orderID });
            }
            else if (OVM.orderID != 0)
            {

                Debug.WriteLine("SECOND");
                Order same = (from stuff in FODBC.Order
                              orderby stuff descending
                              select stuff).FirstOrDefault();
                same.TotalPrice = same.TotalPrice + item.Fruit.Price * item.Quantity;
                FODBC.Order.Update(same);
                FODBC.SaveChanges();

                OrderItem orderItem = new OrderItem
                {
                    OrderId = (from stuff in FODBC.Order
                               orderby stuff.Id descending
                               select stuff.Id).FirstOrDefault(),
                    FruitId = (item.Fruit.Id),
                    Quantity = (item.Quantity),
                    SubTotal = (item.Fruit.Price * item.Quantity),


                };
                if (item.Quantity != 0)
                {
                    FODBC.OrderItem.Add(orderItem);
                    FODBC.SaveChanges();

                }



                Debug.WriteLine(same.TotalPrice);
                return RedirectToAction("Ordering", new { id = same.Id });

            }


            OVM.Fruits = FODBC.Fruit.Include(b => b.FruitCategory).ToList();
            return View(OVM);
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



