using Microsoft.AspNetCore.Mvc;

namespace FiltersInASPNETCoreMVCApp.Controllers
{
    /// <summary>
    /// Cross Site Request Forgery (CSRF) is one of the most severe vulnerabilities which can be exploited in various ways- 
    /// from changing user’s info without his knowledge to gaining full access to user’s account.
    /// </summary>

    public class CSRFExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePassword(string emailId, string newPassword)
        {
            // Update the password in the database
            TempData["Message"] = $"Password updated successfully for {emailId} and password is {newPassword}!";
            return RedirectToAction("Index");
        }


    }
}
