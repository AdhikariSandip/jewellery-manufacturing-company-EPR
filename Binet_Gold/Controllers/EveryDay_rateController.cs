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
    public class EveryDay_rateController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: EveryDay_rate
        public ActionResult Index()
        {
            var everyDay_rate = db.EveryDay_rate.Include(e => e.Date_Time).Include(e => e.Shop_Details);
            return View(everyDay_rate.ToList());
        }

        // GET: EveryDay_rate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EveryDay_rate everyDay_rate = db.EveryDay_rate.Find(id);
            if (everyDay_rate == null)
            {
                return HttpNotFound();
            }
            return View(everyDay_rate);
        }

        // GET: EveryDay_rate/Create
        public ActionResult Create()
        {
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: EveryDay_rate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EveryDay_RateID,Particular,Bikri_Dar,Kharid_Dar,Date,Shop_name")] EveryDay_rate everyDay_rate)
        {
            if (ModelState.IsValid)
            {
                db.EveryDay_rate.Add(everyDay_rate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", everyDay_rate.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", everyDay_rate.Shop_name);
            return View(everyDay_rate);
        }

        // GET: EveryDay_rate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EveryDay_rate everyDay_rate = db.EveryDay_rate.Find(id);
            if (everyDay_rate == null)
            {
                return HttpNotFound();
            }
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", everyDay_rate.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", everyDay_rate.Shop_name);
            return View(everyDay_rate);
        }

        // POST: EveryDay_rate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EveryDay_RateID,Particular,Bikri_Dar,Kharid_Dar,Date,Shop_name")] EveryDay_rate everyDay_rate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(everyDay_rate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", everyDay_rate.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", everyDay_rate.Shop_name);
            return View(everyDay_rate);
        }

        // GET: EveryDay_rate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EveryDay_rate everyDay_rate = db.EveryDay_rate.Find(id);
            if (everyDay_rate == null)
            {
                return HttpNotFound();
            }
            return View(everyDay_rate);
        }

        // POST: EveryDay_rate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EveryDay_rate everyDay_rate = db.EveryDay_rate.Find(id);
            db.EveryDay_rate.Remove(everyDay_rate);
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
