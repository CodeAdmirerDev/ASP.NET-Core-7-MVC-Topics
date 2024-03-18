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
            countryObj.CountryDescription = "Bharat is from the king Bharata, who was the son of Dushyanta and Shakuntala" +
                                            " and the term varsa means a division of the earth or a continent.";
            ViewBag.CountryObjInfo = countryObj;
            return View();
        }
    }
}
