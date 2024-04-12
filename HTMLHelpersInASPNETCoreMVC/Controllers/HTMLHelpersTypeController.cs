using HTMLHelpersInASP.NETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTMLHelpersInASP.NETCoreMVC.Controllers
{
    public class HTMLHelpersTypeController : Controller
    {
        public IActionResult HTMLHelperTagInfo()
        {
            return View();
        }

        public IActionResult TextBoxHelperView()
        {
            return View();
        }

        public IActionResult TextAreaHelperView()
        {

            Product product= new Product();

            product.ProdcutId = 1;
            product.ProdcutName = "LG Mobile";


            return View();
        }


    }
}
