using FiltersInASPNETCoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltersInASPNETCoreMVCApp.Controllers
{
    public class ActionFilterExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [TypeFilter(typeof(CustomLoggerActionFilter))]
        public string TestActionFilterProcess()
        {
            return "Action filter executed please check the logs";
        }
    }
}
