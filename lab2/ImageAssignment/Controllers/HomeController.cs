using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowDetails(int id, string name, string image) 
        {
            ViewBag.id = id;    
            ViewBag.name = name;
            ViewBag.image = image;
            return View();
        }

    }
}