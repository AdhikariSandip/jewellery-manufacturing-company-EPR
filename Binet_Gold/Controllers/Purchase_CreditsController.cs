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
    public class Purchase_CreditsController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Purchase_Credits
        public ActionResult Index()
        {
            var purchase_Credits = db.Purchase_Credits.Include(p => p.Bill_Number1).Include(p => p.Date_Time).Include(p => p.Product_Purchase_Record1).Include(p => p.Shop_Details);
            return View(purchase_Credits.ToList());
        }

        // GET: Purchase_Credits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Credits purchase_Credits = db.Purchase_Credits.Find(id);
            if (purchase_Credits == null)
            {
                return HttpNotFound();
            }
            return View(purchase_Credits);
        }

        // GET: Purchase_Credits/Create
        public ActionResult Create()
        {
            ViewBag.Bill_Number = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1");
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.Product_purchase_record = new SelectList(db.Product_Purchase_Record, "PPR_ID", "Product_name");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Purchase_Credits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Purchase_CreditID,Bill_Number,Product_purchase_record,Payment,Balance,Total_Amount,Date,Shop_name")] Purchase_Credits purchase_Credits)
        {
            if (ModelState.IsValid)
            {
                db.Purchase_Credits.Add(purchase_Credits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bill_Number = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", purchase_Credits.Bill_Number);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", purchase_Credits.Date);
            ViewBag.Product_purchase_record = new SelectList(db.Product_Purchase_Record, "PPR_ID", "Product_name", purchase_Credits.Product_purchase_record);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", purchase_Credits.Shop_name);
            return View(purchase_Credits);
        }

        // GET: Purchase_Credits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Credits purchase_Credits = db.Purchase_Credits.Find(id);
            if (purchase_Credits == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bill_Number = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", purchase_Credits.Bill_Number);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", purchase_Credits.Date);
            ViewBag.Product_purchase_record = new SelectList(db.Product_Purchase_Record, "PPR_ID", "Product_name", purchase_Credits.Product_purchase_record);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", purchase_Credits.Shop_name);
            return View(purchase_Credits);
        }

        // POST: Purchase_Credits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Purchase_CreditID,Bill_Number,Product_purchase_record,Payment,Balance,Total_Amount,Date,Shop_name")] Purchase_Credits purchase_Credits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase_Credits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bill_Number = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", purchase_Credits.Bill_Number);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", purchase_Credits.Date);
            ViewBag.Product_purchase_record = new SelectList(db.Product_Purchase_Record, "PPR_ID", "Product_name", purchase_Credits.Product_purchase_record);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", purchase_Credits.Shop_name);
            return View(purchase_Credits);
        }

        // GET: Purchase_Credits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Credits purchase_Credits = db.Purchase_Credits.Find(id);
            if (purchase_Credits == null)
            {
                return HttpNotFound();
            }
            return View(purchase_Credits);
        }

        // POST: Purchase_Credits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase_Credits purchase_Credits = db.Purchase_Credits.Find(id);
            db.Purchase_Credits.Remove(purchase_Credits);
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
