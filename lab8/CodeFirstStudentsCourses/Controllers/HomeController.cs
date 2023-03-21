using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CodeFirstStudentsCourses.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public HomeController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            var environmentName = _env.EnvironmentName;
            ViewData["EnvironmentName"] = environmentName;
            return View();
        }
    }
}
