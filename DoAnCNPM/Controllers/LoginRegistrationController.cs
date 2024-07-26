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



        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AuthenLogin(User user)
        {
            try
            {
                var checkUser = db.Users
                    .Where(s => s.Username == user.Username && s.Userpassword == user.Userpassword)
                    .FirstOrDefault(); 


                if (checkUser == null)
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                    return View("Login");
                }
                else //Dang nhap thanh cong
                {
                    Session["Username"] = checkUser.Username;
                    Session["UserRole"] = checkUser.UserRole;

                    if (checkUser.UserRole == "Admin")
                    {
                        return RedirectToAction("Index", "AdminHome");
                    }
                    else if (checkUser.UserRole == "Customer")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View("Login");
                    }
                }
            }
            catch
            {
                return View("Login"); //Khi dang nhap that bai, load lai trang login va hien thi loi
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult AuthenRegister(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    return View("Register");
                }

            }
            catch //bao loi
            {

                return View("Register");
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}