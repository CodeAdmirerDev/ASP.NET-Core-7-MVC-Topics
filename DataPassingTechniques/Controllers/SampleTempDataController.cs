using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniques.Controllers
{
    public class SampleTempDataController : Controller
    {
        public IActionResult GetCountryDetails()
        {

            TempData["CountryName"] = "India";
            //TempData["CountryCode"] = "IN";
            ViewData["CountryCode"] = "IN";

            TempData.Keep();
            return RedirectToAction("ContactUs");
        }

        public IActionResult ContactUs()
        {
            ViewData["CountryName"] = TempData.Peek("CountryName");
            TempData.Keep();
            return View();
        }
    }
}
