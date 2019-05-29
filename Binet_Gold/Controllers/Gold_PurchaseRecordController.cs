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
    public class Gold_PurchaseRecordController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Gold_PurchaseRecord
        public ActionResult Index()
        {
            var gold_PurchaseRecord = db.Gold_PurchaseRecord.Include(g => g.Shop_Details);
            return View(gold_PurchaseRecord.ToList());
        }

        // GET: Gold_PurchaseRecord/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gold_PurchaseRecord gold_PurchaseRecord = db.Gold_PurchaseRecord.Find(id);
            if (gold_PurchaseRecord == null)
            {
                return HttpNotFound();
            }
            return View(gold_PurchaseRecord);
        }

        // GET: Gold_PurchaseRecord/Create
        public ActionResult Create()
        {
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Gold_PurchaseRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GP_ID,Vendor_name,Weight,Rate,Amount,Paid,Remaining,Shop_name")] Gold_PurchaseRecord gold_PurchaseRecord)
        {
            if (ModelState.IsValid)
            {
                db.Gold_PurchaseRecord.Add(gold_PurchaseRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", gold_PurchaseRecord.Shop_name);
            return View(gold_PurchaseRecord);
        }

        // GET: Gold_PurchaseRecord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gold_PurchaseRecord gold_PurchaseRecord = db.Gold_PurchaseRecord.Find(id);
            if (gold_PurchaseRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", gold_PurchaseRecord.Shop_name);
            return View(gold_PurchaseRecord);
        }

        // POST: Gold_PurchaseRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GP_ID,Vendor_name,Weight,Rate,Amount,Paid,Remaining,Shop_name")] Gold_PurchaseRecord gold_PurchaseRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gold_PurchaseRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", gold_PurchaseRecord.Shop_name);
            return View(gold_PurchaseRecord);
        }

        // GET: Gold_PurchaseRecord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gold_PurchaseRecord gold_PurchaseRecord = db.Gold_PurchaseRecord.Find(id);
            if (gold_PurchaseRecord == null)
            {
                return HttpNotFound();
            }
            return View(gold_PurchaseRecord);
        }

        // POST: Gold_PurchaseRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gold_PurchaseRecord gold_PurchaseRecord = db.Gold_PurchaseRecord.Find(id);
            db.Gold_PurchaseRecord.Remove(gold_PurchaseRecord);
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
