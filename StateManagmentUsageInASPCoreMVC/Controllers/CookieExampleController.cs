using Microsoft.AspNetCore.Mvc;

namespace StateManagementUsageInASPCoreMVC.Controllers
{
    public class CookieExampleController : Controller
    {
       const string CookieUserId = "UserId";
       const string CookieUserName = "UserName";

        public IActionResult Index()
        {
            CookieOptions options = new CookieOptions()
            {
                Domain="localhost", //Here we need to set the domain for the cookie

                Path="/",//It will available within the entire application

                Expires=DateTime.Now.AddDays(1),//It will expire in 1 day

                Secure=false,//These will ensure cookies will be sent over only in HTTPS(true) , as we runing in localhost you can set to false for now 
               
                HttpOnly=true,//It will prevent the client-side scripts from accessing the cookie
               
                IsEssential=true,//It will represent the cookie is required to funcation in the application

            };

            //Here we are appending the cookie for UserId and UserName
            Response.Cookies.Append(CookieUserId, "EMP123456",options);
            Response.Cookies.Append(CookieUserName, "DemoUser", options);


            return View();
        }
    }
}
