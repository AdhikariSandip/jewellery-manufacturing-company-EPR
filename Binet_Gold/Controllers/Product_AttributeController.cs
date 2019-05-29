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
    public class Product_AttributeController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Product_Attribute
        public ActionResult Index()
        {
            var product_Attribute = db.Product_Attribute.Include(p => p.Bill_Number).Include(p => p.Client).Include(p => p.Date_Time).Include(p => p.Product).Include(p => p.Product_Purchase_Record1).Include(p => p.Shop_Details);
            return View(product_Attribute.ToList());
        }

        // GET: Product_Attribute/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Attribute product_Attribute = db.Product_Attribute.Find(id);
            if (product_Attribute == null)
            {
                return HttpNotFound();
            }
            return View(product_Attribute);
        }

        // GET: Product_Attribute/Create
        public ActionResult Create()
        {
            ViewBag.Bill_ID = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1");
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_name");
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Product_Name");
            ViewBag.Product_Purchase_record = new SelectList(db.Product_Purchase_Record, "PPR_ID", "Product_name");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Product_Attribute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_attributeID,Product_Purchase_record,P_Code,Quality,Net_Weight,Westages,Total_weight,Wages,Product_ID,Diamond_Stone,Rate,Sold_OrNot,Date,Bikri_Date,Client_ID,Bill_ID,Purchase_Date,Shop_name")] Product_Attribute product_Attribute)
        {
            if (ModelState.IsValid)
            {
                db.Product_Attribute.Add(product_Attribute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bill_ID = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", product_Attribute.Bill_ID);
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_name", product_Attribute.Client_ID);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", product_Attribute.Date);
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Product_Name", product_Attribute.Product_ID);
            ViewBag.Product_Purchase_record = new SelectList(db.Product_Purchase_Record, "PPR_ID", "Product_name", product_Attribute.Product_Purchase_record);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", product_Attribute.Shop_name);
            return View(product_Attribute);
        }

        // GET: Product_Attribute/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Attribute product_Attribute = db.Product_Attribute.Find(id);
            if (product_Attribute == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bill_ID = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", product_Attribute.Bill_ID);
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_name", product_Attribute.Client_ID);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", product_Attribute.Date);
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Product_Name", product_Attribute.Product_ID);
            ViewBag.Product_Purchase_record = new SelectList(db.Product_Purchase_Record, "PPR_ID", "Product_name", product_Attribute.Product_Purchase_record);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", product_Attribute.Shop_name);
            return View(product_Attribute);
        }

        // POST: Product_Attribute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_attributeID,Product_Purchase_record,P_Code,Quality,Net_Weight,Westages,Total_weight,Wages,Product_ID,Diamond_Stone,Rate,Sold_OrNot,Date,Bikri_Date,Client_ID,Bill_ID,Purchase_Date,Shop_name")] Product_Attribute product_Attribute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Attribute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bill_ID = new SelectList(db.Bill_Number, "Bill_ID", "Bill_Number1", product_Attribute.Bill_ID);
            ViewBag.Client_ID = new SelectList(db.Clients, "Client_ID", "Client_name", product_Attribute.Client_ID);
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", product_Attribute.Date);
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Product_Name", product_Attribute.Product_ID);
            ViewBag.Product_Purchase_record = new SelectList(db.Product_Purchase_Record, "PPR_ID", "Product_name", product_Attribute.Product_Purchase_record);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", product_Attribute.Shop_name);
            return View(product_Attribute);
        }

        // GET: Product_Attribute/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Attribute product_Attribute = db.Product_Attribute.Find(id);
            if (product_Attribute == null)
            {
                return HttpNotFound();
            }
            return View(product_Attribute);
        }

        // POST: Product_Attribute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Attribute product_Attribute = db.Product_Attribute.Find(id);
            db.Product_Attribute.Remove(product_Attribute);
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
