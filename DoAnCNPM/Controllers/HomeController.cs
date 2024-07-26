using DoAnCNPM.Models;
using DoAnCNPM.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAnCNPM.Controllers
{
    public class HomeController : Controller
    {

        private readonly DB_KingShoesEntities _context;


        public HomeController()
        {
            _context = new DB_KingShoesEntities(); // Tạo mới context
        }
        public HomeController(DB_KingShoesEntities context)
        {
            _context = context;
        }


        // DB_KingShoesEntities db = new  DB_KingShoesEntities();
        public ActionResult Index()
        {
            // Lấy các sản phẩm theo CategoryID
            var NikeProducts = _context.Products.Where(p => p.CategoryID == 1).ToList();
            var AdidasProducts = _context.Products.Where(p => p.CategoryID == 2).ToList();
            var JordanProducts = _context.Products.Where(p => p.CategoryID == 3).ToList();
            var YeezyProducts = _context.Products.Where(p => p.CategoryID == 4).ToList();

            // Tạo ViewModel và truyền dữ liệu vào
            var viewModel = new ProductViewModel
            {
                NikeProducts = NikeProducts,
                AdidasProducts = AdidasProducts,
                JordanProducts = JordanProducts,
                YeezyProducts = YeezyProducts
            };

            return View(viewModel);
        }



        public ActionResult Introduce()
        {
            return View();
        }



    }
}