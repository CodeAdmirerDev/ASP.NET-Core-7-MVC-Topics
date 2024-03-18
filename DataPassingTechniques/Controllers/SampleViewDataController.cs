using DataPassingTechniques.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniques.Controllers
{
    public class SampleViewDataController : Controller
    {
        // GET: SampleViewDataController
        public ActionResult Index()
        {
            //Synatx for ViewData
            // ViewData is a Dicitonary type and is supported key value pair <string, Object>
            // ViewData["KeyName"] = "Your value/ Object data";

            //Eg:
            ViewData["UserName"] = "Suri";

            return View();
        }

        // GET: SampleViewDataController/GetCountryDetails
        public ActionResult GetCountryDetails()
        {

            ViewData["Heading"] = "Below are the Country Details";

            Country countryObj = new Country();

            countryObj.CountryName = "India";
            countryObj.CountryCapital = "New Delhi";
            countryObj.CountryCode = "In";
            countryObj.CountryPopulation = 141000000;
            countryObj.CountryDescription = "Bharat is from the king Bharata, who was the son of Dushyanta and Shakuntala" +
                                            " and the term varsa means a division of the earth or a continent.";

            ViewData["countryObjInfoFromSample"] = countryObj;

            //ViewData will not available for subsequent request 
            ViewData["countryObjInfoFromHome"] = countryObj; //ViewData["countryObjInfo"];
                                                             //-- it is from HomeController Index method
            return View();
        }


    }
}
