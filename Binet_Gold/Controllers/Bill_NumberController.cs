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
    public class Bill_NumberController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Bill_Number
        public ActionResult Index()
        {
            var bill_Number = db.Bill_Number.Include(b => b.Shop_Details);
            return View(bill_Number.ToList());
        }

        // GET: Bill_Number/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Number bill_Number = db.Bill_Number.Find(id);
            if (bill_Number == null)
            {
                return HttpNotFound();
            }
            return View(bill_Number);
        }

        // GET: Bill_Number/Create
        public ActionResult Create()
        {
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Bill_Number/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bill_ID,Bill_Number1,Salesman_Name,Shop_name")] Bill_Number bill_Number)
        {
            if (ModelState.IsValid)
            {
                db.Bill_Number.Add(bill_Number);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", bill_Number.Shop_name);
            return View(bill_Number);
        }

        // GET: Bill_Number/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Number bill_Number = db.Bill_Number.Find(id);
            if (bill_Number == null)
            {
                return HttpNotFound();
            }
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", bill_Number.Shop_name);
            return View(bill_Number);
        }

        // POST: Bill_Number/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bill_ID,Bill_Number1,Salesman_Name,Shop_name")] Bill_Number bill_Number)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill_Number).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", bill_Number.Shop_name);
            return View(bill_Number);
        }

        // GET: Bill_Number/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Number bill_Number = db.Bill_Number.Find(id);
            if (bill_Number == null)
            {
                return HttpNotFound();
            }
            return View(bill_Number);
        }

        // POST: Bill_Number/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill_Number bill_Number = db.Bill_Number.Find(id);
            db.Bill_Number.Remove(bill_Number);
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
