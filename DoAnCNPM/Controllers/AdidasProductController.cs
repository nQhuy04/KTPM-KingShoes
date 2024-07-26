using DoAnCNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAnCNPM.Controllers
{
    public class AdidasProductController : Controller
    {
        DB_KingShoesEntities db = new DB_KingShoesEntities();
        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Where(p => p.CategoryID == 2).ToList();
            return View(products);
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

        public ActionResult Search(string query)
        {
            var products = db.Products
                .Where(p => p.ProductName.Contains(query))
                .ToList();

            return View("SearchResults", products);
        }

        [HttpGet]
        public JsonResult GetSearchSuggestions(string term)
        {
            var suggestions = db.Products
                .Where(p => p.ProductName.StartsWith(term))
                .Select(p => p.ProductName)
                .Take(10)
                .ToList();

            return Json(suggestions, JsonRequestBehavior.AllowGet);
        }
    }
}