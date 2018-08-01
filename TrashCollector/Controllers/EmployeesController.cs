using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var pickupsToday = DateTime.Now.DayOfWeek.ToString();
            string currentUserId = User.Identity.GetUserId();
            Employee me = db.Employees.Where(e => e.Id == currentUserId).FirstOrDefault();
            if (pickupsToday == null)
            {
                return View();
            }
            else
            { 
            var zoneCustomers = db.Customers.Where(c => c.Zipcode == me.ZipCode && c.PickUpDay == pickupsToday);
                return View(zoneCustomers.ToList());
            }

        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,FirstName,LastName,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,LastName,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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


        public ActionResult FilterPickUpsByDay()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterPickupsByDay(Customer customer)
        {
            if (customer.PickUpDay == "Monday")
            {
                return View(db.Customers.ToList());
            }
            if (customer.PickUpDay == "Tuesday")
            {
                return View(db.Customers.ToList());
            }
            if (customer.PickUpDay == "Wednesday")
            {
                return View(db.Customers.ToList());
            }
            if (customer.PickUpDay == "Thursday")
            {
                return View(db.Customers.ToList());
            }
            if (customer.PickUpDay == "Friday")
            {
                return View(db.Customers.ToList());
            }
            if (customer.PickUpDay == "Saturday")
            {
                return View(db.Customers.ToList());
            }
            if (customer.PickUpDay == "Sunday")
            {
                return View(db.Customers.ToList());
            }
            return View();
        }
    }
}
