using HTMLHelpersInASPNETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HTMLHelpersInASPNETCoreMVC.Controllers
{
    public class AllHTMLHelpersController : Controller
    {

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CustomerProfile()
        {

            ViewBag.HobbiesList = new SelectList(new List<string> {"Reading","Watching series","Playing chess" });
            ViewBag.NicknamesList = new SelectList(new List<string> { "Please Select Nick name","Tommy", "Chintu", "Hodder", "Sara" });

            return View();
        }
        [HttpPost]
        public IActionResult CustomerProfile(CustomerProfile customerProfile)
        {
            customerProfile.CustomerId = 1;

            if (ModelState.IsValid)
            {
                //you can write the logic to store the data in DB
                //Just for the response i am redirecting this to Success page 

                TempData["IsCustomerProfileCreated"] = "Customer profile is created!";
                return RedirectToAction("Success");

            }

            ViewBag.HobbiesList = new SelectList(new List<string> { "Reading", "Watching series", "Playing chess" });
            ViewBag.NicknamesList = new SelectList(new List<string> { "Please Select Nick name", "Tommy", "Chintu", "Hodder", "Sara" });

            return View(customerProfile);
        }

      
    }
}
