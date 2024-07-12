using DoAnCNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCNPM.Controllers
{
    public class ProducrtClientController : Controller
    {
        DB_KingShoesEntities db = new DB_KingShoesEntities();
        // GET: ProducrtClient
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}