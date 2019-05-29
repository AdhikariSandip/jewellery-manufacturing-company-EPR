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
    public class Shop_Debtor_AccountController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Shop_Debtor_Account
        public ActionResult Index()
        {
            var shop_Debtor_Account = db.Shop_Debtor_Account.Include(s => s.Bill_Number1).Include(s => s.Client1).Include(s => s.Date_Time).Include(s => s.Shop_Details);
            return View(shop_Debtor_Account.ToList());
        }

        // GET: Shop_Debtor_Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop_Debtor_Account shop_Debtor_Account = db.Shop_Debtor_Account.Find(id);
            if (shop_Debtor_Account == null)
            {
                return HttpNotFound();
            }
            return View(shop_Debtor_Account);
        }

        // GET: Shop_Debtor_Account/Create
        public ActionResult Create()
        {
            ViewBag.Bill_Number = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1");
            ViewBag.Client = new SelectList(db.Clients, "Client_ID", "Client_name");
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Shop_Debtor_Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShopDebtor_ID,Date,Bill_Number,Client,Total_amount,Payment,Balance,Shop_name")] Shop_Debtor_Account shop_Debtor_Account)
        {
            if (ModelState.IsValid)
            {
                db.Shop_Debtor_Account.Add(shop_Debtor_Account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bill_Number = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", shop_Debtor_Account.Bill_Number);
            ViewBag.Client = new SelectList(db.Clients, "Client_ID", "Client_name", shop_Debtor_Account.Client);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", shop_Debtor_Account.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", shop_Debtor_Account.Shop_name);
            return View(shop_Debtor_Account);
        }

        // GET: Shop_Debtor_Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop_Debtor_Account shop_Debtor_Account = db.Shop_Debtor_Account.Find(id);
            if (shop_Debtor_Account == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bill_Number = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", shop_Debtor_Account.Bill_Number);
            ViewBag.Client = new SelectList(db.Clients, "Client_ID", "Client_name", shop_Debtor_Account.Client);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", shop_Debtor_Account.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", shop_Debtor_Account.Shop_name);
            return View(shop_Debtor_Account);
        }

        // POST: Shop_Debtor_Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShopDebtor_ID,Date,Bill_Number,Client,Total_amount,Payment,Balance,Shop_name")] Shop_Debtor_Account shop_Debtor_Account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shop_Debtor_Account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bill_Number = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", shop_Debtor_Account.Bill_Number);
            ViewBag.Client = new SelectList(db.Clients, "Client_ID", "Client_name", shop_Debtor_Account.Client);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", shop_Debtor_Account.Date);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", shop_Debtor_Account.Shop_name);
            return View(shop_Debtor_Account);
        }

        // GET: Shop_Debtor_Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop_Debtor_Account shop_Debtor_Account = db.Shop_Debtor_Account.Find(id);
            if (shop_Debtor_Account == null)
            {
                return HttpNotFound();
            }
            return View(shop_Debtor_Account);
        }

        // POST: Shop_Debtor_Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop_Debtor_Account shop_Debtor_Account = db.Shop_Debtor_Account.Find(id);
            db.Shop_Debtor_Account.Remove(shop_Debtor_Account);
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
