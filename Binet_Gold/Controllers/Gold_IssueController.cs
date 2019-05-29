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
    public class Gold_IssueController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Gold_Issue
        public ActionResult Index()
        {
            var gold_Issue = db.Gold_Issue.Include(g => g.Client1).Include(g => g.Date_Time).Include(g => g.Employee_Details).Include(g => g.Shop_Details);
            return View(gold_Issue.ToList());
        }

        // GET: Gold_Issue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gold_Issue gold_Issue = db.Gold_Issue.Find(id);
            if (gold_Issue == null)
            {
                return HttpNotFound();
            }
            return View(gold_Issue);
        }

        // GET: Gold_Issue/Create
        public ActionResult Create()
        {
            ViewBag.Client = new SelectList(db.Clients, "Client_ID", "Client_name");
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.Employee_ID = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Gold_Issue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gold_IssueID,Particular,Weight,Order_Weight,Rate,Return_Date,Return_Prod_Weight,Return_tukraSun,Lost_Sun,Lost_amount,Order_OrNot,Wages,NumberOfItems_Received,Employee_ID,Client,Date,Shop_name")] Gold_Issue gold_Issue)
        {
            if (ModelState.IsValid)
            {
                db.Gold_Issue.Add(gold_Issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Client = new SelectList(db.Clients, "Client_ID", "Client_name", gold_Issue.Client);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", gold_Issue.Date);
            ViewBag.Employee_ID = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code", gold_Issue.Employee_ID);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", gold_Issue.Shop_name);
            return View(gold_Issue);
        }

        // GET: Gold_Issue/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gold_Issue gold_Issue = db.Gold_Issue.Find(id);
            if (gold_Issue == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client = new SelectList(db.Clients, "Client_ID", "Client_name", gold_Issue.Client);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", gold_Issue.Date);
            ViewBag.Employee_ID = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code", gold_Issue.Employee_ID);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", gold_Issue.Shop_name);
            return View(gold_Issue);
        }

        // POST: Gold_Issue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gold_IssueID,Particular,Weight,Order_Weight,Rate,Return_Date,Return_Prod_Weight,Return_tukraSun,Lost_Sun,Lost_amount,Order_OrNot,Wages,NumberOfItems_Received,Employee_ID,Client,Date,Shop_name")] Gold_Issue gold_Issue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gold_Issue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client = new SelectList(db.Clients, "Client_ID", "Client_name", gold_Issue.Client);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", gold_Issue.Date);
            ViewBag.Employee_ID = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code", gold_Issue.Employee_ID);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", gold_Issue.Shop_name);
            return View(gold_Issue);
        }

        // GET: Gold_Issue/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gold_Issue gold_Issue = db.Gold_Issue.Find(id);
            if (gold_Issue == null)
            {
                return HttpNotFound();
            }
            return View(gold_Issue);
        }

        // POST: Gold_Issue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gold_Issue gold_Issue = db.Gold_Issue.Find(id);
            db.Gold_Issue.Remove(gold_Issue);
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
