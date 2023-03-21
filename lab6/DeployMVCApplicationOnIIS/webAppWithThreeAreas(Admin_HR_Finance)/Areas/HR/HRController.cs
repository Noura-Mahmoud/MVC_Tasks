using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webAppWithThreeAreas_Admin_HR_Finance_.Areas.HR
{
    public class HRController : Controller
    {
        // GET: HR/HR
        public ActionResult Index()
        {
            return View();
        }
    }
}