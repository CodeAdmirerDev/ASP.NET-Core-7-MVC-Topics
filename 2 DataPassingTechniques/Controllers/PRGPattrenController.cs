using DataPassingTechniques.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniques.Controllers
{
    public class PRGPattrenController : Controller
    {

        static int i = 0;
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitCountryData(Country country)
        {
            if(ModelState.IsValid)
            {
                // Here you can do any modifications such as DB insert 

                TempData["IsCountryDataSaved"] = "Country data saved successfully";

                return RedirectToAction(nameof(Success));
                /*
                If you want to see the actual problem with form re-Submit
                    uncomment below code and execute and also comment the 24th line.                
                 */

                //i = i + 1;
                //TempData["CountOfReSubmission"] = i;
                //return View();
            }

            return View("Index",country);

        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
