using FiltersInASPNETCoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltersInASPNETCoreMVCApp.Controllers
{
    [TypeFilter(typeof(CustomExceptionFilter))]
    public class ExceptionFilterExampleController : Controller
    {
        public IActionResult Index()
        {
            string name = null;

            string fname = name.Split(' ')[0];
            return View();
        }

        [TypeFilter(typeof(RedirectToSpecificErrorViewFilter))]
        public IActionResult WithOutExceptionFilter()
        {

            string name = null;

            string fname = name.Split(' ')[0];

            return View();
        }


    }
}
