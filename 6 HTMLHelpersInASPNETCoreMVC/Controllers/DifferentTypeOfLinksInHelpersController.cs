using Microsoft.AspNetCore.Mvc;

namespace HTMLHelpersInASPNETCoreMVC.Controllers
{
    public class DifferentTypeOfLinksInHelpersController : Controller
    {
        [HttpGet]
        public IActionResult AllLinksTypesInHTMLHelpers()
        {

            return View();
        }
    }
}
