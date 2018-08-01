using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var customerInfo = (from c in db.Customers where c.Id.Equals(userId) select c);
            customerInfo.ToList();
            return View(customerInfo);
        }

        // GET: Customers/Details/5
        public ActionResult AmountDue(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,StreetAddress,Zipcode,")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,StreetAddress,Zipcode,PickUpDay")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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

        public ActionResult PickUpDay(int? id)
        {
            var update = (from u in db.Customers where u.CustomerId == id select u).FirstOrDefault();
            return View(update);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PickUpDay([Bind(Include = "CustomerId, FirstName, LastName, StreetAddress, Zipcode, PickUpDay, OneTimePickUp")]Customer customer)
        {
            Customer pickup = (from p in db.Customers where p.CustomerId == customer.CustomerId select p).FirstOrDefault();
            if (ModelState.IsValid)
            {
                pickup.PickUpDay = customer.PickUpDay;
                db.Entry(pickup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult OneTimeCollection(int? id)
        {
            var update = (from u in db.Customers where u.CustomerId == id select u).FirstOrDefault();
            return View(update);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OneTimeCollection([Bind(Include = "CustomerId, FirstName, LastName, StreetAddress, Zipcode, PickUpDay, OneTimePickUp")]Customer customer)
        {
            Customer pickup = (from p in db.Customers where p.CustomerId == customer.CustomerId select p).FirstOrDefault();
            if (ModelState.IsValid)
            {
                pickup.OneTimePickUp = customer.OneTimePickUp;
                db.Entry(pickup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult TemporaryHalt(int? id)
        {
            var update = (from u in db.Customers where u.CustomerId == id select u).FirstOrDefault();
            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TemporaryHalt([Bind(Include = "CustomerId, FirstName, LastName, StreetAddress, Zipcode, PickUpDay, OneTimePickUp, StartDate, EndDate")]Customer customer)
        {
            Customer setDates = (from p in db.Customers where p.CustomerId == customer.CustomerId select p).FirstOrDefault();
            if (ModelState.IsValid)
            {
                setDates.StartDate = customer.StartDate;
                setDates.EndDate = customer.EndDate;
                db.Entry(setDates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
