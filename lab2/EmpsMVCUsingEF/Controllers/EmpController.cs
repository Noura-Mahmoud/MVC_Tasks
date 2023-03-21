using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpsMVCUsingEF.Models;
// on running:   Emp/Index
namespace EmpsMVCUsingEF.Controllers
{
    public class EmpController : Controller
    {

        EMPLOYEESEntities1 context = new EMPLOYEESEntities1(); //context
        // GET: Emp
        public ActionResult Index()
        {
            ViewBag.depts = context.Depts.ToList();
            return View(context.Emps);
        }
        [HttpPost]
        public ActionResult Index(int dID)
        {
            ViewBag.depts = context.Depts.ToList();
            //ViewBag.emps = context.Emps.Where(e => e.dID == dID).ToList();
            return View(context.Emps.Where(e => e.dID == dID));
        }

        // GET: Emp/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.emp = context.Emps.Find(id);
            return View(context.Emps.Find(id));
            //return View();
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            ViewBag.depts = context.Depts.ToList();
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(Emp employee)
        {
            try
            {
                // TODO: Add insert logic here
                Emp emp = new Emp();
                emp.EmpLname = employee.EmpLname;
                emp.EmpFname = employee.EmpFname;
                emp.dID = employee.dID;
                emp.EmpSalary = employee.EmpSalary;
                emp.EmpHDate = employee.EmpHDate;
                context.Emps.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            Emp emp = context.Emps.Find(id);
            ViewBag.depts = context.Depts.ToList();
            return View(emp);
        }

        // POST: Emp/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        Emp emp = context.Emps.Find(id);
        //        emp.EmpLname = collection["EmpLname"];
        //        emp.EmpFname = collection["EmpFname"];
        //        emp.dID = int.Parse(collection["dID"]);
        //        emp.EmpSalary = double.Parse(collection["EmpSalary"]);
        //        emp.EmpHDate = DateTime.Parse(collection["EmpHDate"]);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult Edit(int id, Emp employee)
        {
            try
            {
                // TODO: Add update logic here
                Emp emp = context.Emps.Find(id);
                emp.EmpLname = employee.EmpLname;
                emp.EmpFname = employee.EmpFname;
                emp.dID = employee.dID;
                emp.EmpSalary = employee.EmpSalary;
                emp.EmpHDate = employee.EmpHDate;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            Emp emp = context.Emps.Find(id);
            return View(emp);
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                context.Emps.Remove(context.Emps.Find(id));
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
