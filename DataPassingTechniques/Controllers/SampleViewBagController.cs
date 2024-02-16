using DataPassingTechniques.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniques.Controllers
{
    public class SampleViewBagController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.HeaderMsg = "Country Information";

            Country countryObj = new Country();

            countryObj.CountryName = "Bharat";
            countryObj.CountryCapital = "New Delhi";
            countryObj.CountryCode = "In";
            countryObj.CountryPopulation = 141000000;
            countryObj.CountryDescription = "India got the freedom on 1947";

            ViewBag.CountryObjInfo = countryObj;

            return View();
        }
    }
}
