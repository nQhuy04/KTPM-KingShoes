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
                var check_Username = db.Users.Where(s => s.Username==user.Username).FirstOrDefault(); /*FirstOnDefault là đặt con trỏ ở đầu dòng để đối chiếu*/
                var check_Userpassword = db.Users.Where(s => s.Userpassword==user.Userpassword).FirstOrDefault();


                if (check_Username ==null || check_Userpassword==null)
                {
                    if (check_Username == null)
                        ViewBag.ErrorUsername = "Ten Dang Nhap khong hop le";
                    if (check_Userpassword == null)
                        ViewBag.ErrorUserpassword = "Mat Khau khong hop le";
                    return View("Login");
                }
                else //Dang nhap thanh cong
                {
                    Session["Username"] = user.Username;
                    return RedirectToAction("Index", "Home");
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