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
    public class Contract_PersonsController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Contract_Persons
        public ActionResult Index()
        {
            var contract_Persons = db.Contract_Persons.Include(c => c.Date_Time).Include(c => c.Employee_Details).Include(c => c.Shop_Details);
            return View(contract_Persons.ToList());
        }

        // GET: Contract_Persons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract_Persons contract_Persons = db.Contract_Persons.Find(id);
            if (contract_Persons == null)
            {
                return HttpNotFound();
            }
            return View(contract_Persons);
        }

        // GET: Contract_Persons/Create
        public ActionResult Create()
        {
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.CP_Name = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Contract_Persons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CP_ID,CP_Name,Shop_name,Date,Particular,Amount,Payment")] Contract_Persons contract_Persons)
        {
            if (ModelState.IsValid)
            {
                db.Contract_Persons.Add(contract_Persons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", contract_Persons.Date);
            ViewBag.CP_Name = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code", contract_Persons.CP_Name);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", contract_Persons.Shop_name);
            return View(contract_Persons);
        }

        // GET: Contract_Persons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract_Persons contract_Persons = db.Contract_Persons.Find(id);
            if (contract_Persons == null)
            {
                return HttpNotFound();
            }
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", contract_Persons.Date);
            ViewBag.CP_Name = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code", contract_Persons.CP_Name);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", contract_Persons.Shop_name);
            return View(contract_Persons);
        }

        // POST: Contract_Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CP_ID,CP_Name,Shop_name,Date,Particular,Amount,Payment")] Contract_Persons contract_Persons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract_Persons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", contract_Persons.Date);
            ViewBag.CP_Name = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code", contract_Persons.CP_Name);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", contract_Persons.Shop_name);
            return View(contract_Persons);
        }

        // GET: Contract_Persons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract_Persons contract_Persons = db.Contract_Persons.Find(id);
            if (contract_Persons == null)
            {
                return HttpNotFound();
            }
            return View(contract_Persons);
        }

        // POST: Contract_Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract_Persons contract_Persons = db.Contract_Persons.Find(id);
            db.Contract_Persons.Remove(contract_Persons);
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
