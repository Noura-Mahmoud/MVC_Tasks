using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webAppWhichManagesCustomersAndThierOrders.Data;
using webAppWhichManagesCustomersAndThierOrders.Models;

namespace webAppWhichManagesCustomersAndThierOrders.Controllers
{
    public class OrdersController : Controller
    {
        private webAppWhichManagesCustomersAndThierOrdersContext db = new webAppWhichManagesCustomersAndThierOrdersContext();

        // GET: Orders
        public ActionResult Index()
        {
            //ViewBag.orders = db.Orders.ToList();
            ViewBag.customers = db.Customers.ToList();
            return View(db.Orders);
        }

        [HttpPost]
        //custom handleErrorAttribute
        [UserNotFoundErrorHandler]
        //[Route("Orders/{custID}")]
        public ActionResult Index(int ID)
        {
            //ViewBag.orders = db.Orders.ToList();
            ViewBag.customers = db.Customers.ToList();
            if (db.Orders.Where(o => o.CustID == ID).Count() == 0)
                throw new Exception();
            return View(db.Orders.Where(o => o.CustID == ID));
        }
        //Handle errors in each Controller using different ErrorViewPage
        [HandleError( View = "OrdersErrorView")]
        public ActionResult Error()
        {
            throw new DivideByZeroException();
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustID = new SelectList(db.Customers, "ID", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,TotalPrice,CustID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustID = new SelectList(db.Customers, "ID", "Name", order.CustID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustID = new SelectList(db.Customers, "ID", "Name", order.CustID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,TotalPrice,CustID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustID = new SelectList(db.Customers, "ID", "Name", order.CustID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
