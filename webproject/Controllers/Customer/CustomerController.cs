using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webproject.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private DataContext db = new DataContext();

        [Route("~/Customer")]
        [Route("index")]
        
        public IActionResult Index()
        {
            ViewBag.customers = db.Customer.ToList();
            return View();
        }

        //[Route("")]
        //[Route("~/Customer")]
        //[Route("result")]
        
        //public IActionResult Result(string Name)
        //{
        //    //Customer.CreationDate = DateTime.Now;
        //    //Customer.ExpiredDate = DateTime.Now;
        //    var customers = from s in db.Customer
        //                 select s;
        //    if (!String.IsNullOrEmpty(Name))
        //    {
        //        customers = customers.Where(s => s.Name.Contains(Name));
        //        ViewBag.Customers = customers.ToList();
        //    }
        //    //db.Customer.Add(Customer);
        //    //db.SaveChanges();
        //    return View();
        //}

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
            db.Customer.Remove(db.Customer.Find(Id));
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
        public IActionResult Add(Customer customer)
        {
            
            db.Customer.Add(customer);
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
            //Customer.CreationDate = DateTime.Now;
            //Customer.ExpiredDate = DateTime.Now;
            var customers = from s in db.Customer
                         select s;
            if (!String.IsNullOrEmpty(Name) && (searchBy == "Fname"))
            {
                customers = customers.Where(s => s.Fname.Contains(Name));
                ViewBag.customers = customers.ToList();
            }
            
            if (!String.IsNullOrEmpty(Name) && (searchBy == "Lname"))
            {
                customers = customers.Where(s => s.Lname.Contains(Name));
                ViewBag.customers = customers.ToList();
            }
            if (!String.IsNullOrEmpty(Name) && (searchBy == "Address"))
            {
                customers = customers.Where(s => s.Address.Contains(Name));
                ViewBag.customers = customers.ToList();
            }

            if (!String.IsNullOrEmpty(Name) && (searchBy == "Phone"))
            {
                customers = customers.Where(s => s.Phone.Contains(Name));
                ViewBag.customers = customers.ToList();
            }

            

            //db.Customer.Add(Customer);
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
        public IActionResult Edit(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult Index(string name, string price,)
        //{
        //    ViewBag.Name = string.Format("Name: {0} {1}", name, price,);
        //    return View();
        //}
        //public ActionResult Add(int Id, string name, string description, decimal price)
        ////public IActionResult Add(Customer Customer)
        //{
        //    var Customer = new Customer();
        //if (ModelState.IsValid)
        //{
        //    ViewBag.Customer = Customer;
        //    db.Customer.Add(Customer);
        //       db.SaveChanges();
        //       return RedirectToAction("Index");
        //}
        //else
        //{
        //    return View("Index");
        //}
        //try
        //{
        //    ViewData["Id"] = Id;
        //    ViewData["Name"] = name;
        //    ViewData["Description"] = description;
        //    //ViewData["Address"] = address;
        //    Customer.Id = ViewBag.Id;
        //    Customer.Name = ViewBag.Name;
        //    Customer.Description = ViewBag.Description;
        //    Customer.Price = ViewBag.Price;
        //    Customer.ExpiredDate = DateTime.Now;
        //    Customer.CreationDate = DateTime.Now;
        //    db.Customer.Add(Customer);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //catch
        //{
        //    return View();
        //}
        // }

    }
}

