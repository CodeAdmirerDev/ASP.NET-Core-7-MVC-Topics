using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TypesOfViewsInASPNETCore.Models;

namespace TypesOfViewsInASPNETCore.Controllers
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
        public IActionResult SectionsIndex()
        {
            return View();
        }


        public IActionResult ViewStartExample()
        {
            return View();
        }
        public ViewResult Details()
        {
            return View();
        }
        public ViewResult SectionsDetails()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
