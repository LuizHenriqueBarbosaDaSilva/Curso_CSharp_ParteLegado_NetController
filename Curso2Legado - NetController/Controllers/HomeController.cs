using System.Diagnostics;
using Curso2Legado___NetController.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso2Legado___NetController.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {

            ViewData["Message"] = "Your application description page.";
            ViewData["email"] = "luiz@gmail.com";

            ViewData["Message2"] = "Salles Web MVC App from C# Course";
            ViewData["Professor"] = "Nelio Alves";


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
