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
    public class General_LedgerController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: General_Ledger
        public ActionResult Index()
        {
            var general_Ledger = db.General_Ledger.Include(g => g.Date_Time).Include(g => g.Shop_Details);
            return View(general_Ledger.ToList());
        }

        // GET: General_Ledger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General_Ledger general_Ledger = db.General_Ledger.Find(id);
            if (general_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(general_Ledger);
        }

        // GET: General_Ledger/Create
        public ActionResult Create()
        {
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: General_Ledger/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GL_ID,Ledger_Description,Debit,Credit,Balance,Date,Shop_name")] General_Ledger general_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.General_Ledger.Add(general_Ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", general_Ledger.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", general_Ledger.Shop_name);
            return View(general_Ledger);
        }

        // GET: General_Ledger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General_Ledger general_Ledger = db.General_Ledger.Find(id);
            if (general_Ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", general_Ledger.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", general_Ledger.Shop_name);
            return View(general_Ledger);
        }

        // POST: General_Ledger/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GL_ID,Ledger_Description,Debit,Credit,Balance,Date,Shop_name")] General_Ledger general_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(general_Ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", general_Ledger.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", general_Ledger.Shop_name);
            return View(general_Ledger);
        }

        // GET: General_Ledger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General_Ledger general_Ledger = db.General_Ledger.Find(id);
            if (general_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(general_Ledger);
        }

        // POST: General_Ledger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            General_Ledger general_Ledger = db.General_Ledger.Find(id);
            db.General_Ledger.Remove(general_Ledger);
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
