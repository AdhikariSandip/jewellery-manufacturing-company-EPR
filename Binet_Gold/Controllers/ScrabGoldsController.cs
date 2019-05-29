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
    public class ScrabGoldsController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: ScrabGolds
        public ActionResult Index()
        {
            var scrabGolds = db.ScrabGolds.Include(s => s.Shop_Details);
            return View(scrabGolds.ToList());
        }

        // GET: ScrabGolds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrabGold scrabGold = db.ScrabGolds.Find(id);
            if (scrabGold == null)
            {
                return HttpNotFound();
            }
            return View(scrabGold);
        }

        // GET: ScrabGolds/Create
        public ActionResult Create()
        {
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: ScrabGolds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScrabGold_ID,Scrab_Gold_Weight,BuyPercent,Rate,Amount,Shop_name")] ScrabGold scrabGold)
        {
            if (ModelState.IsValid)
            {
                db.ScrabGolds.Add(scrabGold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", scrabGold.Shop_name);
            return View(scrabGold);
        }

        // GET: ScrabGolds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrabGold scrabGold = db.ScrabGolds.Find(id);
            if (scrabGold == null)
            {
                return HttpNotFound();
            }
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", scrabGold.Shop_name);
            return View(scrabGold);
        }

        // POST: ScrabGolds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScrabGold_ID,Scrab_Gold_Weight,BuyPercent,Rate,Amount,Shop_name")] ScrabGold scrabGold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scrabGold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", scrabGold.Shop_name);
            return View(scrabGold);
        }

        // GET: ScrabGolds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrabGold scrabGold = db.ScrabGolds.Find(id);
            if (scrabGold == null)
            {
                return HttpNotFound();
            }
            return View(scrabGold);
        }

        // POST: ScrabGolds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScrabGold scrabGold = db.ScrabGolds.Find(id);
            db.ScrabGolds.Remove(scrabGold);
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
