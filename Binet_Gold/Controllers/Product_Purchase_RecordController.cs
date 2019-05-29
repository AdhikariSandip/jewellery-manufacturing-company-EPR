using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Binet_Gold.Models;

namespace Binet_Gold.Controllers
{
    public class Product_Purchase_RecordController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Product_Purchase_Record
        public ActionResult Index()
        {
            var product_Purchase_Record = db.Product_Purchase_Record.Include(p => p.Shop_Details);
            return View(product_Purchase_Record.ToList());
        }

        // GET: Product_Purchase_Record/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Purchase_Record product_Purchase_Record = db.Product_Purchase_Record.Find(id);
            if (product_Purchase_Record == null)
            {
                return HttpNotFound();
            }
            return View(product_Purchase_Record);
        }

        // GET: Product_Purchase_Record/Create
        public ActionResult Create()
        {
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Product_Purchase_Record/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PPR_ID,Product_name,Address,Phone_Number,Shop_name")] Product_Purchase_Record product_Purchase_Record)
        {
            if (ModelState.IsValid)
            {
                db.Product_Purchase_Record.Add(product_Purchase_Record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", product_Purchase_Record.Shop_name);
            return View(product_Purchase_Record);
        }

        // GET: Product_Purchase_Record/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Purchase_Record product_Purchase_Record = db.Product_Purchase_Record.Find(id);
            if (product_Purchase_Record == null)
            {
                return HttpNotFound();
            }
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", product_Purchase_Record.Shop_name);
            return View(product_Purchase_Record);
        }

        // POST: Product_Purchase_Record/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PPR_ID,Product_name,Address,Phone_Number,Shop_name")] Product_Purchase_Record product_Purchase_Record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Purchase_Record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", product_Purchase_Record.Shop_name);
            return View(product_Purchase_Record);
        }

        // GET: Product_Purchase_Record/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Purchase_Record product_Purchase_Record = db.Product_Purchase_Record.Find(id);
            if (product_Purchase_Record == null)
            {
                return HttpNotFound();
            }
            return View(product_Purchase_Record);
        }

        // POST: Product_Purchase_Record/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Purchase_Record product_Purchase_Record = db.Product_Purchase_Record.Find(id);
            db.Product_Purchase_Record.Remove(product_Purchase_Record);
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
