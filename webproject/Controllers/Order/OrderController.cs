using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webproject.Controllers
{
    [Route("order")]
    public class OrderController : Controller
    {
        private DataContext db = new DataContext();

        [Route("~/Order")]
        [Route("index")]
       
        public IActionResult Index()
        {
            ViewBag.orders = db.Order.ToList();
            return View();
        }

        
        [Route("delete")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View("Delete");
        }

        [Route("delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            db.Order.Remove(db.Order.Find(Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add(Order order)
        {
            order.CustomerID = 1;
             order.ProductID = 1;

            db.Order.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("search")]
        [HttpGet]
        public IActionResult Search()
        {

            return View();
        }

        [Route("search")]
        [HttpPost]

        public IActionResult Search(string searchBy, string Name)
        {
            //Order.CreationDate = DateTime.Now;
            //Order.ExpiredDate = DateTime.Now;
            var orders = from s in db.Order
                         select s;
            
            
           
            if (!String.IsNullOrEmpty(Name) && (searchBy == "Status"))
            {
                orders = orders.Where(s => s.Status.Contains(Name));
                ViewBag.orders = orders.ToList();
            }

            if (!String.IsNullOrEmpty(Name) && (searchBy == "Qty"))
            {
                orders = orders.Where(s => s.Qty== Int16.Parse(Name));
                ViewBag.orders = orders.ToList();
            }



            //db.Order.Add(Order);
            //db.SaveChanges();
            return View(); 
        }
        [Route("edit")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View("Edit");
        }

        [Route("edit")]
        [HttpPost]
        public IActionResult Edit(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

  

    }
}

