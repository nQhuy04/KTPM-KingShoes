using DoAnCNPM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAnCNPM.Controllers
{
    public class ArchiveController : Controller
    {
        // GET: Archive
        private DB_KingShoesEntities db = new DB_KingShoesEntities();

        // GET: Archive
        public ActionResult Index()
        {
            var archives = db.Archives.Include(a => a.Product).ToList();
            return View(archives);
        }

        // GET: Archive/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: Archive/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArchiveID,ProductID,Stock")] Archive archive)
        {
            if (ModelState.IsValid)
            {
                db.Archives.Add(archive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", archive.ProductID);
            return View(archive);
        }

        // GET: Archive/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archive archive = db.Archives.Find(id);
            if (archive == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", archive.ProductID);
            return View(archive);
        }

        // POST: Archive/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArchiveID,ProductID,Stock")] Archive archive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", archive.ProductID);
            return View(archive);
        }

        // GET: Archive/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archive archive = db.Archives.Include(a => a.Product).FirstOrDefault(a => a.ArchiveID == id);
            if (archive == null)
            {
                return HttpNotFound();
            }
            return View(archive);
        }

        // POST: Archive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Archive archive = db.Archives.Find(id);
            db.Archives.Remove(archive);
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