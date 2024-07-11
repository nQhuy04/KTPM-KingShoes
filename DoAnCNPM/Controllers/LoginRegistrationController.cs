using DoAnCNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DoAnCNPM.Controllers
{
    public class LoginRegistrationController : Controller
    {

        DB_KingShoesEntities db = new DB_KingShoesEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register(User user)
        {
            if(db.Users.Any(x=>x.Username == user.Username))
            {
                ViewBag.Notification = "Tài khoản này đã tồn tại";
                return View();
            }
            else
            {
                db.Users.Add(user);
                 db.SaveChanges();

                Session["UserID"] = user.UserID.ToString();
                Session["Username"] = user.Username.ToString();
                return RedirectToAction("Login", "LoginRegistration");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(User user)
        {
            var checklogin = db.Users.Where(x=>x.Username.Equals(user.Username)&& x.Password.Equals(user.Password)).FirstOrDefault();
            if(checklogin != null)
            {
                Session["UserID"] = user.UserID.ToString();
                Session["Username"] = user.UserID.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Tên Đăng Nhập hoặc Mật Khẩu không chính xác";
            }
            return View();
        }


    }
}