using DoAnCNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAnCNPM.Controllers
{
    public class CustomerProductsController : Controller
    {
        DB_KingShoesEntities db = new DB_KingShoesEntities();
        // GET: CustomerProducts
        public ActionResult Index()
        {
            var products = db.Products;
            return View(products.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}