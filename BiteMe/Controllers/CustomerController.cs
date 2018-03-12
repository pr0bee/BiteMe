using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BiteMe.DAL;
using BiteMe.Models;

namespace BiteMe.Controllers
{
    public class CustomerController : Controller
    {
        private BiteMeContext db = new BiteMeContext();

        // GET: Customer
        public ActionResult Index(string searchString, string sortByLastName)
        {
            // Δημιουργία κενού πεδίου searchString για έυρεση συγκεκριμένου LastName (γρ. 23-28 & στο View γρ. 13-19)

            var customers = from x in db.Customers select x;
            
            if(!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.LastName.Contains(searchString));
            }

            // Λειτουργία για sortByLastName με το σκεπτικό να κρατάει το πιθανό επόμενο βήμα κάθε φορά που την επιλέγουμε (γρ. 32-40, δεν παίζει ακόμα)

            ViewBag.NameSortParameter = String.IsNullOrEmpty(sortByLastName) ? "name_desc" : "";
            var customersSort = from s in db.Customers select s;
            switch (sortByLastName)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(x => x.LastName);
                    break;
                default:
                    customers = customers.OrderBy(x => x.LastName);
                    break;
            }

            // εδώ θέλει κάτι άλλο?
            return View(customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
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

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Address,ZipCode,Email,Password,Phone,Gender,OrderID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
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

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Address,ZipCode,Email,Password,Phone,Gender,OrderID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
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

        // POST: Customer/Delete/5
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
    }
}
