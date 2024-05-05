using HTMLHelpersInASP.NETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HTMLHelpersInASP.NETCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string isRequestFromOtherController,string controllerName)
        {
            if (isRequestFromOtherController =="Yes")
            {
                TempData["RequestType"] = "It is from " + controllerName;

            }
            return View();
        }

        public IActionResult Privacy()
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
