using DoAnCNPM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCNPM.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: AdminProduct
        private DB_KingShoesEntities db = new DB_KingShoesEntities();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Include("Category").ToList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = db.Products.Include("Category").FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/assets/images/"), fileName);
                    imageFile.SaveAs(path);
                    product.ImageProduct = "~/assets/images/" + fileName;
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var existingProduct = db.Products.Find(product.ProductID);
                    if (existingProduct == null)
                    {
                        return HttpNotFound();
                    }

                    if (imageFile != null && imageFile.ContentLength > 0)
                    {
                        // Xử lý lưu ảnh mới
                        string imagePath = Path.Combine(Server.MapPath("~/Assets/Images"), Path.GetFileName(imageFile.FileName));
                        imageFile.SaveAs(imagePath);
                        product.ImageProduct = "~/Assets/Images/" + imageFile.FileName;
                    }
                    else
                    {
                        // Giữ nguyên ảnh cũ
                        product.ImageProduct = existingProduct.ImageProduct;
                    }

                    db.Entry(existingProduct).CurrentValues.SetValues(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


                db.Products.Attach(product);
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }


        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = new Product { ProductID = id };
            db.Products.Attach(product);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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