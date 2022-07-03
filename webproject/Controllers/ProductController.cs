using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webproject.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.products = db.Product.ToList();
            return View();
        }

        [Route("")]
        [Route("~/Product")]
        [Route("result")]
        
        public IActionResult Result(string Name)
        {
            //product.CreationDate = DateTime.Now;
            //product.ExpiredDate = DateTime.Now;
            var products = from s in db.Product
                         select s;
            if (!String.IsNullOrEmpty(Name))
            {
                products = products.Where(s => s.Name.Contains(Name));
                ViewBag.products = products.ToList();
            }
            //db.Product.Add(product);
            //db.SaveChanges();
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
            db.Product.Remove(db.Product.Find(Id));
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
        public IActionResult Add(Product product)
        {
            product.CreationDate = DateTime.Now;
            product.ExpiredDate = DateTime.Now;

            db.Product.Add(product);
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
            //product.CreationDate = DateTime.Now;
            //product.ExpiredDate = DateTime.Now;
            var products = from s in db.Product
                         select s;
            if (!String.IsNullOrEmpty(Name) && (searchBy == "Name"))
            {
                products = products.Where(s => s.Name.Contains(Name));
                ViewBag.products = products.ToList();
            }
            if (!String.IsNullOrEmpty(Name) && (searchBy == "Price"))
            {
                products = products.Where(s => s.Price == (Convert.ToDecimal(Name, System.Globalization.CultureInfo.InvariantCulture)));
                ViewBag.products = products.ToList();
            }
            if (!String.IsNullOrEmpty(Name) && (searchBy == "Description"))
            {
                products = products.Where(s => s.Description.Contains(Name));
                ViewBag.products = products.ToList();
            }
            


            //db.Product.Add(product);
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
        public IActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
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
        ////public IActionResult Add(Product product)
        //{
        //    var product = new Product();
        //if (ModelState.IsValid)
        //{
        //    ViewBag.product = product;
        //    db.Product.Add(product);
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
        //    product.Id = ViewBag.Id;
        //    product.Name = ViewBag.Name;
        //    product.Description = ViewBag.Description;
        //    product.Price = ViewBag.Price;
        //    product.ExpiredDate = DateTime.Now;
        //    product.CreationDate = DateTime.Now;
        //    db.Product.Add(product);
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

