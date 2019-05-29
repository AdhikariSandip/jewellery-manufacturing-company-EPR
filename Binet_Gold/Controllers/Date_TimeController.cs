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
    public class Date_TimeController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Date_Time
        public ActionResult Index()
        {
            return View(db.Date_Time.ToList());
        }

        // GET: Date_Time/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date_Time date_Time = db.Date_Time.Find(id);
            if (date_Time == null)
            {
                return HttpNotFound();
            }
            return View(date_Time);
        }

        // GET: Date_Time/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Date_Time/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date_Time_ID,Date_Time1")] Date_Time date_Time)
        {
            if (ModelState.IsValid)
            {
                db.Date_Time.Add(date_Time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(date_Time);
        }

        // GET: Date_Time/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date_Time date_Time = db.Date_Time.Find(id);
            if (date_Time == null)
            {
                return HttpNotFound();
            }
            return View(date_Time);
        }

        // POST: Date_Time/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date_Time_ID,Date_Time1")] Date_Time date_Time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(date_Time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(date_Time);
        }

        // GET: Date_Time/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date_Time date_Time = db.Date_Time.Find(id);
            if (date_Time == null)
            {
                return HttpNotFound();
            }
            return View(date_Time);
        }

        // POST: Date_Time/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Date_Time date_Time = db.Date_Time.Find(id);
            db.Date_Time.Remove(date_Time);
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
