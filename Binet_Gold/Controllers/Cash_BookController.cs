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
    public class Cash_BookController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Cash_Book
        public ActionResult Index()
        {
            var cash_Book = db.Cash_Book.Include(c => c.Date_Time).Include(c => c.Shop_Details);
            return View(cash_Book.ToList());
        }

        // GET: Cash_Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cash_Book cash_Book = db.Cash_Book.Find(id);
            if (cash_Book == null)
            {
                return HttpNotFound();
            }
            return View(cash_Book);
        }

        // GET: Cash_Book/Create
        public ActionResult Create()
        {
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Cash_Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cash_bookID,Particular,Debit,credit,Date,Shop_name")] Cash_Book cash_Book)
        {
            if (ModelState.IsValid)
            {
                db.Cash_Book.Add(cash_Book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", cash_Book.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", cash_Book.Shop_name);
            return View(cash_Book);
        }

        // GET: Cash_Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cash_Book cash_Book = db.Cash_Book.Find(id);
            if (cash_Book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", cash_Book.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", cash_Book.Shop_name);
            return View(cash_Book);
        }

        // POST: Cash_Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cash_bookID,Particular,Debit,credit,Date,Shop_name")] Cash_Book cash_Book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cash_Book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", cash_Book.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", cash_Book.Shop_name);
            return View(cash_Book);
        }

        // GET: Cash_Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cash_Book cash_Book = db.Cash_Book.Find(id);
            if (cash_Book == null)
            {
                return HttpNotFound();
            }
            return View(cash_Book);
        }

        // POST: Cash_Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cash_Book cash_Book = db.Cash_Book.Find(id);
            db.Cash_Book.Remove(cash_Book);
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
