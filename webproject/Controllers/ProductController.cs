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
            db.Product.Remove(db.Product.Find(ViewData["Id"]));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
