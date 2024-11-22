using Microsoft.AspNetCore.Mvc;

namespace TagHelpersInASPNETCoreMVC.Controllers
{
    public class CustomTagHelperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RecentPostsInfo()
        {
            return View();
        }
    }
}
