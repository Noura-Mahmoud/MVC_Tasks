using Microsoft.AspNetCore.Mvc;

namespace DotNetFiveCarWebAppCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
