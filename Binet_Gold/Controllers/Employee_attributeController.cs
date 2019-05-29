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
    public class Employee_attributeController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Employee_attribute
        public ActionResult Index()
        {
            var employee_attribute = db.Employee_attribute.Include(e => e.Date_Time).Include(e => e.Employee_Details).Include(e => e.Shop_Details);
            return View(employee_attribute.ToList());
        }

        // GET: Employee_attribute/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_attribute employee_attribute = db.Employee_attribute.Find(id);
            if (employee_attribute == null)
            {
                return HttpNotFound();
            }
            return View(employee_attribute);
        }

        // GET: Employee_attribute/Create
        public ActionResult Create()
        {
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID");
            ViewBag.Employee = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Employee_attribute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_attribute_ID,Particular,Employee,Salary,Payment,Remaining,Date,Shop_name")] Employee_attribute employee_attribute)
        {
            if (ModelState.IsValid)
            {
                db.Employee_attribute.Add(employee_attribute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", employee_attribute.Date);
            ViewBag.Employee = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code", employee_attribute.Employee);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", employee_attribute.Shop_name);
            return View(employee_attribute);
        }

        // GET: Employee_attribute/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_attribute employee_attribute = db.Employee_attribute.Find(id);
            if (employee_attribute == null)
            {
                return HttpNotFound();
            }
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", employee_attribute.Date);
            ViewBag.Employee = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code", employee_attribute.Employee);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", employee_attribute.Shop_name);
            return View(employee_attribute);
        }

        // POST: Employee_attribute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_attribute_ID,Particular,Employee,Salary,Payment,Remaining,Date,Shop_name")] Employee_attribute employee_attribute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_attribute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Date = new SelectList(db.Date_Time, "Date_Time_ID", "Date_Time_ID", employee_attribute.Date);
            ViewBag.Employee = new SelectList(db.Employee_Details, "Employee_ID", "Employee_Code", employee_attribute.Employee);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", employee_attribute.Shop_name);
            return View(employee_attribute);
        }

        // GET: Employee_attribute/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_attribute employee_attribute = db.Employee_attribute.Find(id);
            if (employee_attribute == null)
            {
                return HttpNotFound();
            }
            return View(employee_attribute);
        }

        // POST: Employee_attribute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_attribute employee_attribute = db.Employee_attribute.Find(id);
            db.Employee_attribute.Remove(employee_attribute);
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
