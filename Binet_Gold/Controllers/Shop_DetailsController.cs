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
    public class Shop_DetailsController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Shop_Details
        public ActionResult Index()
        {
            return View(db.Shop_Details.ToList());
        }

        // GET: Shop_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop_Details shop_Details = db.Shop_Details.Find(id);
            if (shop_Details == null)
            {
                return HttpNotFound();
            }
            return View(shop_Details);
        }

        // GET: Shop_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Shop_ID,Shop_name,Shop_Address")] Shop_Details shop_Details)
        {
            if (ModelState.IsValid)
            {
                db.Shop_Details.Add(shop_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shop_Details);
        }

        // GET: Shop_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop_Details shop_Details = db.Shop_Details.Find(id);
            if (shop_Details == null)
            {
                return HttpNotFound();
            }
            return View(shop_Details);
        }

        // POST: Shop_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Shop_ID,Shop_name,Shop_Address")] Shop_Details shop_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shop_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop_Details);
        }

        // GET: Shop_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop_Details shop_Details = db.Shop_Details.Find(id);
            if (shop_Details == null)
            {
                return HttpNotFound();
            }
            return View(shop_Details);
        }

        // POST: Shop_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop_Details shop_Details = db.Shop_Details.Find(id);
            db.Shop_Details.Remove(shop_Details);
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
