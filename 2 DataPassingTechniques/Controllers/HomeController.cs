using DataPassingTechniques.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataPassingTechniques.Controllers
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

            Country countryObj = new Country();

            countryObj.CountryName = "Bharat";
            countryObj.CountryCapital = "New Delhi";
            countryObj.CountryCode = "In";
            countryObj.CountryPopulation = 141000000;
            countryObj.CountryDescription = "India got the freedom on 1947";

            ViewData["countryObjInfo"] = countryObj;

            return RedirectToAction("GetCountryDetails", "SampleViewData");
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
