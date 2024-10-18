using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StateManagementUsageInASPCoreMVC.Controllers
{
    public class UsingSessionsInASPNETController : Controller
    {
        public IActionResult Index()
        {           

            return View();
        }

        public IActionResult SetSessionValue()
        {
            HttpContext.Session.SetInt32("IntUserId", 123456);
            HttpContext.Session.SetString("StringUserId", "12345");
            return View();
        }

        public IActionResult ReadSessionValue()
        {

            int? useridint = HttpContext.Session.GetInt32("IntUserId");
            if (useridint != null)
            {
                ViewBag.IntUserId = useridint.Value;
            }

            ViewBag.StringUserId = HttpContext.Session.GetString("StringUserId");


            return View();
        }

        public IActionResult AccessSessionObjectInView()
        {


            return View();
        }



        }
}
