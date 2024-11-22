using DataPassingTechniques.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniques.Controllers
{
    public class SampleStronglyTypedViewController : Controller
    {
        public IActionResult GetCountryDetails()
        {

            Country countryObj = new Country();

            countryObj.CountryName = "India";
            countryObj.CountryCapital = "New Delhi";
            countryObj.CountryCode = "In";
            countryObj.CountryPopulation = 141000000;
            countryObj.CountryDescription = "India got the freedom on 1947";

            return View(countryObj);
        }
    }
}
