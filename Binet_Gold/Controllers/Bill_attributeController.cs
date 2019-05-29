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
    public class Bill_attributeController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Bill_attribute
        public ActionResult Index()
        {
            var bill_attribute = db.Bill_attribute.Include(b => b.Bill_Number).Include(b => b.Client).Include(b => b.Date_Time).Include(b => b.ScrabGold).Include(b => b.Shop_Details);
            return View(bill_attribute.ToList());
        }

        // GET: Bill_attribute/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_attribute bill_attribute = db.Bill_attribute.Find(id);
            if (bill_attribute == null)
            {
                return HttpNotFound();
            }
            return View(bill_attribute);
        }

        // GET: Bill_attribute/Create
        public ActionResult Create()
        {
            ViewBag.Bill_NumID = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1");
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_name");
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.ScrabGold_ID = new SelectList(db.ScrabGolds, "ScrabGold_ID", "ScrabGold_ID");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Bill_attribute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bill_attributeID,Paid_amount,Rate,Discount,Client_ID,Bill_NumID,ScrabGold_ID,Date,Shop_name")] Bill_attribute bill_attribute)
        {
            if (ModelState.IsValid)
            {
                db.Bill_attribute.Add(bill_attribute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bill_NumID = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", bill_attribute.Bill_NumID);
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_name", bill_attribute.Client_ID);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", bill_attribute.Date);
            ViewBag.ScrabGold_ID = new SelectList(db.ScrabGolds, "ScrabGold_ID", "ScrabGold_ID", bill_attribute.ScrabGold_ID);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", bill_attribute.Shop_name);
            return View(bill_attribute);
        }

        // GET: Bill_attribute/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_attribute bill_attribute = db.Bill_attribute.Find(id);
            if (bill_attribute == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bill_NumID = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", bill_attribute.Bill_NumID);
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_name", bill_attribute.Client_ID);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", bill_attribute.Date);
            ViewBag.ScrabGold_ID = new SelectList(db.ScrabGolds, "ScrabGold_ID", "ScrabGold_ID", bill_attribute.ScrabGold_ID);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", bill_attribute.Shop_name);
            return View(bill_attribute);
        }

        // POST: Bill_attribute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bill_attributeID,Paid_amount,Rate,Discount,Client_ID,Bill_NumID,ScrabGold_ID,Date,Shop_name")] Bill_attribute bill_attribute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill_attribute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bill_NumID = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", bill_attribute.Bill_NumID);
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_name", bill_attribute.Client_ID);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", bill_attribute.Date);
            ViewBag.ScrabGold_ID = new SelectList(db.ScrabGolds, "ScrabGold_ID", "ScrabGold_ID", bill_attribute.ScrabGold_ID);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", bill_attribute.Shop_name);
            return View(bill_attribute);
        }

        // GET: Bill_attribute/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_attribute bill_attribute = db.Bill_attribute.Find(id);
            if (bill_attribute == null)
            {
                return HttpNotFound();
            }
            return View(bill_attribute);
        }

        // POST: Bill_attribute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill_attribute bill_attribute = db.Bill_attribute.Find(id);
            db.Bill_attribute.Remove(bill_attribute);
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
