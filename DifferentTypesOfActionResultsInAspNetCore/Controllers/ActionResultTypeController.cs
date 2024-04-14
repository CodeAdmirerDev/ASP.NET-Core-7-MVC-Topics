using Microsoft.AspNetCore.Mvc;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class ActionResultTypeController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }

        //ActionResult is a Abstract class
        public ActionResult GetInfo(string typeOfInfo)
        {
            if (typeOfInfo == "HTML")
            {
                return View();

            }
            else if (typeOfInfo == "json")
            {
                return Json("User selected Json output");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }


        public ActionResult DisplayProductListDetailsInTableFormat()
        {
            return View();

        }

    }
}
