using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using webAppWhichManagesCustomersAndThierOrders.Data;
using webAppWhichManagesCustomersAndThierOrders.Models;

namespace webAppWhichManagesCustomersAndThierOrders.Controllers
{
    [RoutePrefix("Customers/Managing")] // To Apply "RoutePrefix" on The whole controller
    // now we need to add this prefix to get it
    ////////////////////////////////////// Apply "RoutePrefix" on Customer controller ///////////////////////it deosn't work/////////////
    public class CustomersController : Controller
    {
        private webAppWhichManagesCustomersAndThierOrdersContext db = new webAppWhichManagesCustomersAndThierOrdersContext();

        // GET: Customers
        [Route("Index")]
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        [Route("Viewing/Details/{id}")]

        // u need to write (/Viewing/Details/1) to access the details of first customer
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


        [Route("Error")]
        //Handle errors in each Controller using different ErrorViewPage
        [HandleError(View = "CustomersErrorView")]
        public ActionResult Error()
        {
            throw new DivideByZeroException();
        }


        // GET: Customers/Create
        [Route("Create")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]

        public ActionResult Create([Bind(Include = "ID,Name,Gender,Email,PhoneNum")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        [Route("Edit/{id}")]

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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]

        public ActionResult Edit([Bind(Include = "ID,Name,Gender,Email,PhoneNum")] Customer customer)
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
        [Route("Delete/{id}")]

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
        [Route("Delete/{id}")]

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
