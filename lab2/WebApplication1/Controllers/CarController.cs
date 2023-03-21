using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.MobileControls;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult getAll()
        {
            List<Car> cars = CarList.Cars; 
            ViewBag.cars = cars;
            return View();
        }
        public ActionResult getByID(int id) 
        {
            ViewBag.SelectedCar = CarList.Cars.FirstOrDefault(c => c.Num == id);
            return View();
        }
        public ActionResult delete(int id)
        {
            CarList.Cars.Remove(CarList.Cars.FirstOrDefault(c => c.Num == id));
            return RedirectToAction("getAll");
        }
        public ActionResult edit(int id)
        {
            ViewBag.SelectedCar = CarList.Cars.FirstOrDefault(c => c.Num == id);
            return View();
        }
        [HttpPost]
        public ActionResult edit(int id, string color, string model, string manfacture)
        {
            Car updatedCar = CarList.Cars.FirstOrDefault(c=>c.Num == id);
            
            updatedCar.Num = id;
            updatedCar.Color = color;
            updatedCar.Model = model;
            updatedCar.Manfacture = manfacture;
            return RedirectToAction("getAll");
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(int num, string color, string model, string manfacture)
        {
            CarList.Cars.Add(new Car() { Num = num, Color = color, Model = model, Manfacture = manfacture });
            return RedirectToAction("getAll");
        }
    }
}