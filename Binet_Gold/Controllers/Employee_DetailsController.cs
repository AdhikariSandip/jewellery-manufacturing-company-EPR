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
    public class Employee_DetailsController : Controller
    {
        private Binet_Gold_Model db = new Binet_Gold_Model();

        // GET: Employee_Details
        public ActionResult Index()
        {
            var employee_Details = db.Employee_Details.Include(e => e.Post1).Include(e => e.Shop_Details);
            return View(employee_Details.ToList());
        }

        // GET: Employee_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Details employee_Details = db.Employee_Details.Find(id);
            if (employee_Details == null)
            {
                return HttpNotFound();
            }
            return View(employee_Details);
        }

        // GET: Employee_Details/Create
        public ActionResult Create()
        {
            ViewBag.Post = new SelectList(db.Posts, "Post_ID", "Post_Name");
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name");
            return View();
        }

        // POST: Employee_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,Employee_Code,Employee_Name,Employee_Address,Employee_PhoneNumber,Employee_nationality,Post,Shop_name")] Employee_Details employee_Details)
        {
            if (ModelState.IsValid)
            {
                db.Employee_Details.Add(employee_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Post = new SelectList(db.Posts, "Post_ID", "Post_Name", employee_Details.Post);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", employee_Details.Shop_name);
            return View(employee_Details);
        }

        // GET: Employee_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Details employee_Details = db.Employee_Details.Find(id);
            if (employee_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Post = new SelectList(db.Posts, "Post_ID", "Post_Name", employee_Details.Post);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", employee_Details.Shop_name);
            return View(employee_Details);
        }

        // POST: Employee_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,Employee_Code,Employee_Name,Employee_Address,Employee_PhoneNumber,Employee_nationality,Post,Shop_name")] Employee_Details employee_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Post = new SelectList(db.Posts, "Post_ID", "Post_Name", employee_Details.Post);
            ViewBag.Shop_name = new SelectList(db.Shop_Details, "Shop_ID", "Shop_name", employee_Details.Shop_name);
            return View(employee_Details);
        }

        // GET: Employee_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Details employee_Details = db.Employee_Details.Find(id);
            if (employee_Details == null)
            {
                return HttpNotFound();
            }
            return View(employee_Details);
        }

        // POST: Employee_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_Details employee_Details = db.Employee_Details.Find(id);
            db.Employee_Details.Remove(employee_Details);
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
