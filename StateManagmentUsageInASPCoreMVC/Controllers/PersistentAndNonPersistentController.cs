using Microsoft.AspNetCore.Mvc;

namespace StateManagementUsageInASPCoreMVC.Controllers
{
    public class PersistentAndNonPersistentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersistentCookieView()
        {

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1),//It will expire in 1 day
                Secure = true,//These will ensure cookies will be sent over only in HTTPS(true)
                HttpOnly = true,//It will prevent the client-side scripts from accessing the cookie
                IsEssential = true,//It will represent the cookie is required to funcation in the application
            };

            //Here we are appending the Persistent cookie for UserId
            Response.Cookies.Append("PersistentUserId", "12345", options);
            return View();
        }

        public IActionResult NonPersistentCookieView()
        {

            CookieOptions options = new CookieOptions()
            {
                Secure = true,//These will ensure cookies will be sent over only in HTTPS(true)
                HttpOnly = true,//It will prevent the client-side scripts from accessing the cookie
                IsEssential = true,//It will represent the cookie is required to funcation in the application
            };

            //Here we are appending the Persistent cookie for UserId
            Response.Cookies.Append("NonPersistentUserId", "123456", options);
            return View();
        }

    }
}
