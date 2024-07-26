using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnCNPM.Models;


namespace DoAnCNPM.Controllers
{
    public class CartController : Controller
    {
        DB_KingShoesEntities db = new DB_KingShoesEntities();

        public ActionResult Index()
        {
            return View();
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> myCart = Session["GioHang"] as List<CartItem>;
            if (myCart == null)
            {
                myCart = new List<CartItem>();
                Session["GioHang"] = myCart;
            }
            return myCart;
        }

        public ActionResult AddToCart(int id, int quantity, int size)
        {
            List<CartItem> cart = GetCart();
            Product product = db.Products.Find(id);
            if (product != null)
            {
                CartItem existingItem = cart.FirstOrDefault(c => c.ProductID == id && c.Size == size);
                if (existingItem != null)
                {
                    existingItem.Number += quantity;
                }
                else
                {
                    cart.Add(new CartItem
                    {
                        ProductID = product.ProductID,
                        NamePro = product.ProductName,
                        ImagePro = product.ImageProduct,
                        Number = quantity,
                        Price = product.Price ?? 0m,
                        Size = size
                    });
                }
            }
            return RedirectToAction("GetCartInfo");
        }

        private int GetTotalNumber()
        {
            List<CartItem> myCart = GetCart();
            return myCart?.Sum(sp => sp.Number) ?? 0;
        }

        private decimal GetTotalPrice()
        {
            List<CartItem> myCart = GetCart();
            return myCart?.Sum(sp => sp.FinalPrice()) ?? 0;
        }

        public ActionResult GetCartInfo()
        {
            List<CartItem> myCart = GetCart();
            if (myCart == null || myCart.Count == 0)
            {
                return RedirectToAction("Index", "NikeProduct");
            }
            ViewBag.TotalNumber = GetTotalNumber();
            ViewBag.TotalPrice = GetTotalPrice();
            return View(myCart);
        }

        public ActionResult CartPartial()
        {
            ViewBag.TotalNumber = GetTotalNumber();
            ViewBag.TotalPrice = GetTotalPrice();
            return PartialView();
        }

        public ActionResult BuyNow(int id, int quantity, int size)
        {
            List<CartItem> myCart = GetCart();
            CartItem currentProduct = myCart.FirstOrDefault(p => p.ProductID == id && p.Size == size);

            if (currentProduct == null)
            {
                currentProduct = new CartItem(id)
                {
                    Number = quantity,
                    Size = size
                };
                myCart.Add(currentProduct);
            }
            else
            {
                currentProduct.Number = quantity;
            }

            return RedirectToAction("Checkout");
        }

        public ActionResult Checkout()
        {
            List<CartItem> myCart = GetCart();
            if (myCart == null || myCart.Count == 0)
            {
                return RedirectToAction("Index", "NikeProduct");
            }

            ViewBag.TotalNumber = GetTotalNumber();
            ViewBag.TotalPrice = GetTotalPrice();
            return View(myCart);
        }

        [HttpPost]
        public ActionResult ProcessPayment()
        {
            Session["GioHang"] = null;
            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou()
        {
            ViewBag.Message = "Cảm ơn bạn đã mua hàng!";
            return View();
        }

        public JsonResult GetCartCount()
        {
            int cartCount = GetTotalNumber(); // Sử dụng GetTotalNumber để lấy số lượng sản phẩm
            return Json(cartCount, JsonRequestBehavior.AllowGet);
        }
    }
}