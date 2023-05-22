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
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FOS_L1_201945D.Controllers
{
   
    [Authorize]
    public class OrdersController : Microsoft.AspNetCore.Mvc.Controller
    {
        FruitsOrderDBContext FODBC;
        FOUserDBContext userDB;
        
        public OrdersController(FruitsOrderDBContext context,FOUserDBContext context2)
        {
            FODBC = context;
            userDB = context2;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
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
            OrderVM OVM = new OrderVM
            {
                Fruits = FODBC.Fruit.Include(b => b.FruitCategory).ToList(),
                itemList = new List<Items>(),

            };

            
            // REPL;ACE WITH FOR LOOP COZ FIRST ITEM CAN BE NULL BUT NOT SUBSEQUENMT
           // if there is any thats not null convert
           for(int i = 0;i<5;i++)
            {
                if(HttpContext.Session.GetString("Item" + i) != null)
                {
                    var item = JsonConvert.DeserializeObject<Items>(HttpContext.Session.GetString("Item" + i));
                    OVM.itemList.Add(item);
                }
            }
                
            
           /* while (HttpContext.Session.GetString("Item" + x) != null)
            {
                var item = JsonConvert.DeserializeObject<Items>(HttpContext.Session.GetString("Item"+x));
                OVM.itemList.Add(item);
                x++;
            }
            while (HttpContext.Session.GetString("Item" + x+1) != null)
            {
                var item = JsonConvert.DeserializeObject<Items>(HttpContext.Session.GetString("Item" + x));
                OVM.itemList.Add(item);
                x++;
            }*/
            return View(OVM);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Ordering(OrderVM OVM)
        {

            Items item = new Items
            {
                Fruit = (from fruit in FODBC.Fruit 
                         where fruit.Id == OVM.SelectedFruitId
                         select fruit).FirstOrDefault(),
                Quantity = OVM.quantity,
                
            };
            
            if(OVM.Address != null)
            {
                HttpContext.Session.SetString("address", OVM.Address);

            }
            if(OVM.Date != null)
            {
                HttpContext.Session.SetString("date", OVM.Date.ToString());
            }

            OVM.itemList = new List<Items>();
            

            int y = 0;
            //UPDATE OF QUANTITY
            while (HttpContext.Session.GetString("Item" + y) != null)
            {
                var cartItems = JsonConvert.DeserializeObject<Items>(HttpContext.Session.GetString("Item" + y));
                if (cartItems.Fruit.Id == item.Fruit.Id)
                {    //DELETE
                     HttpContext.Session.Remove("Item" + y);
                    break;
                }
                y++;
            }
            //CONVERT TO SESSION AND ADD
            if(item.Quantity > 0)
            {
                HttpContext.Session.SetString("Item" + y, JsonConvert.SerializeObject(item));
                //IF ITEM IS FOUND JUST UPDATE THE QUANTITY DELETE FROM SESSION TOO
            }
            for (int i = 0; i < 200; i++)
            {
                if (HttpContext.Session.GetString("Item" + i) != null)
                {
                    var cartItems = JsonConvert.DeserializeObject<Items>(HttpContext.Session.GetString("Item" + i));

                    OVM.itemList.Add(cartItems);
                }
            }


            OVM.Address = HttpContext.Session.GetString("address");
            DateTime.TryParse(HttpContext.Session.GetString("date"), out DateTime result);
            OVM.Date = result;
            OVM.Fruits = FODBC.Fruit.Include(b => b.FruitCategory).ToList();
            Debug.WriteLine("Loaded");
            return View(OVM);
        }

        public IActionResult RemoveItem(int id)
        {
           /* int x = 0;
            while (HttpContext.Session.GetString("Item" + x) != null)
            {
                var cartItems = JsonConvert.DeserializeObject<Items>(HttpContext.Session.GetString("Item" + x));
                if(cartItems.Fruit.Id == id)
                {
                    HttpContext.Session.Remove("Item" + x);
                }
                x++;
            }*/
            for (int i = 0; i < 5; i++)
            {
                if (HttpContext.Session.GetString("Item" + i) != null)
                {
                    var item = JsonConvert.DeserializeObject<Items>(HttpContext.Session.GetString("Item" + i));

                    if (item.Fruit.Id == id)
                    {
                        HttpContext.Session.Remove("Item" + i);
                    }
                
                }
            }
            
            
            return RedirectToAction("Ordering", "Orders");
        }
        
        public IActionResult Checkout(OrderVM OVM)
        {
            
            List<OrderItem> list = new List<OrderItem>();
            List<Items> item = new List<Items>();
           
            decimal total = 0;
            for (int i = 0; i < 200; i++)
            {
                if (HttpContext.Session.GetString("Item" + i) != null)
                {
                    var cartItems = JsonConvert.DeserializeObject<Items>(HttpContext.Session.GetString("Item" + i));

                    //OVM.itemList.Add(cartItems);
                    var price = (from fruit in FODBC.Fruit
                                 where fruit.Id == cartItems.Fruit.Id
                                 select fruit.Price).FirstOrDefault();
                    
                    OrderItem oi = new OrderItem
                    {
                        FruitId = cartItems.Fruit.Id,
                        Quantity = cartItems.Quantity,
                        SubTotal = cartItems.Quantity * price,
                    };
                    total = total + oi.SubTotal;
                    list.Add(oi);
                }
            }
            Order order = new Order()
            {
                Address = OVM.Address,
                ContactNumber = (from users in userDB.AspNetUsers
                                 where users.UserName == User.Identity.Name
                                 select users.PhoneNumber).FirstOrDefault(),
                Date = OVM.Date,
                TotalPrice = total,
                UserName = User.Identity.Name,
            };

            FODBC.Order.Add(order);
            FODBC.SaveChanges();

            foreach(var x in list)
            {
                x.OrderId = (from stuff in FODBC.Order
                             orderby stuff.Id descending
                             select stuff.Id).FirstOrDefault();
                FODBC.OrderItem.Add(x);
                FODBC.SaveChanges();
            }

            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
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

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult orderHistory(int id)
        {
            
            var order = from b in FODBC.Order
                        where b.Id == id & b.UserName == User.Identity.Name
                        select b;


            return View(order.ToList());
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult viewItems(int? id)
        {

            var orderItems = from b in FODBC.OrderItem.Include(f => f.Fruit).Include(f => f.Fruit.FruitCategory)
                             where b.OrderId == id
                             select b;


            return View(orderItems.ToList());
        }

    }

}




