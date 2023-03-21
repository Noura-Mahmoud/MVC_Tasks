using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webAppWithThreeAreas_Admin_HR_Finance_.Areas.Finance
{
    public class FinanceController : Controller
    {
        // GET: Finance/Finance
        public ActionResult Index()
        {
            return View();
        }
    }
}