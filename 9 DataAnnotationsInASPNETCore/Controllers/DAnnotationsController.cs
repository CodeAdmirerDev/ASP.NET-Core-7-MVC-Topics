using DataAnnotationsInASPNETCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAnnotationsInASPNETCore.Controllers
{
    public class DAnnotationsController : Controller
    {
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("Scucess");
            }


            return View(user);
        }

        public IActionResult Scucess()
        {
            return View();
        }
    }
}
