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
    public class Journal_VoucherController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Journal_Voucher
        public ActionResult Index()
        {
            var journal_Voucher = db.Journal_Voucher.Include(j => j.Account1).Include(j => j.Date_Time).Include(j => j.Shop_Details);
            return View(journal_Voucher.ToList());
        }

        // GET: Journal_Voucher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal_Voucher journal_Voucher = db.Journal_Voucher.Find(id);
            if (journal_Voucher == null)
            {
                return HttpNotFound();
            }
            return View(journal_Voucher);
        }

        // GET: Journal_Voucher/Create
        public ActionResult Create()
        {
            ViewBag.Account = new SelectList(db.Accounts, "Account_ID", "Account_Name");
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.Shop_Name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Journal_Voucher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Journal_ID,Date,Shop_Name,Particular,Account,Ledger_Folio,Debit,Credit")] Journal_Voucher journal_Voucher)
        {
            if (ModelState.IsValid)
            {
                db.Journal_Voucher.Add(journal_Voucher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Account = new SelectList(db.Accounts, "Account_ID", "Account_Name", journal_Voucher.Account);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", journal_Voucher.Date);
            ViewBag.Shop_Name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", journal_Voucher.Shop_Name);
            return View(journal_Voucher);
        }

        // GET: Journal_Voucher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal_Voucher journal_Voucher = db.Journal_Voucher.Find(id);
            if (journal_Voucher == null)
            {
                return HttpNotFound();
            }
            ViewBag.Account = new SelectList(db.Accounts, "Account_ID", "Account_Name", journal_Voucher.Account);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", journal_Voucher.Date);
            ViewBag.Shop_Name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", journal_Voucher.Shop_Name);
            return View(journal_Voucher);
        }

        // POST: Journal_Voucher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Journal_ID,Date,Shop_Name,Particular,Account,Ledger_Folio,Debit,Credit")] Journal_Voucher journal_Voucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journal_Voucher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Account = new SelectList(db.Accounts, "Account_ID", "Account_Name", journal_Voucher.Account);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", journal_Voucher.Date);
            ViewBag.Shop_Name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", journal_Voucher.Shop_Name);
            return View(journal_Voucher);
        }

        // GET: Journal_Voucher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal_Voucher journal_Voucher = db.Journal_Voucher.Find(id);
            if (journal_Voucher == null)
            {
                return HttpNotFound();
            }
            return View(journal_Voucher);
        }

        // POST: Journal_Voucher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Journal_Voucher journal_Voucher = db.Journal_Voucher.Find(id);
            db.Journal_Voucher.Remove(journal_Voucher);
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
