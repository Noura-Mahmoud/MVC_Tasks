using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult test()
        {
            //return View("hi test page");
            //ViewResult result = new ViewResult();
            //result.ViewName = "test";
            //return result;
            ViewData["msg"] = "this is zefy msg";

            ViewBag.msg = "hamada";
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}