using Microsoft.AspNetCore.Mvc;

namespace AddingBootstrapInASPNETCore.Controllers
{
    public class NavMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
