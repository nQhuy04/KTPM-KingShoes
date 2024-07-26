using DoAnCNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCNPM.Controllers
{
    public class AdminOrderController : Controller
    {
        // GET: AdminOrder
        private DB_KingShoesEntities db = new DB_KingShoesEntities();

        // GET: Order
        public ActionResult Index()
        {
            var paidOrders = db.Orders.Where(o => o.OrderDate != null).ToList();
            return View(paidOrders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            var order = db.Orders.Include("OrderDetails.Product").FirstOrDefault(o => o.OrderID == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}