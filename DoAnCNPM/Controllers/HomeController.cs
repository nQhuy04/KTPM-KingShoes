using DoAnCNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCNPM.Controllers
{
    public class HomeController : Controller
    {

        DB_KingShoesEntities db = new  DB_KingShoesEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Introduce()
        {
            return View();
        }



    }
}