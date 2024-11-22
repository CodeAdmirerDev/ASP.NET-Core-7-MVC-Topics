using Microsoft.AspNetCore.Mvc;

namespace StateManagementUsageInASPCoreMVC.Controllers
{
    public class CookieExampleController : Controller
    {
       const string CookieUserId = "UserId";
       const string CookieUserName = "UserName";

        // 1 -- Sending the cookies info from server to client broswer
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
            Response.Cookies.Append(CookieUserId, "12345",options);
            Response.Cookies.Append(CookieUserName, "DemoUser", options);


            return View();
        }

        // 2 -- Accessing the cookies info in view page
        public IActionResult ToSeeCookiesOnViewPage()
        {

            return View();
        }

        // 3 -- Reading the cookies info in the another method 
        public IActionResult AccessCookiesInAnotherMethod()
        {

            string? UsernameVal = Request.Cookies.ContainsKey(CookieUserName) ? Request.Cookies[CookieUserName] : null;

            int UserIdVal = 0;

            if (Request.Cookies.ContainsKey(CookieUserId)) {

               bool isValidUserId = int.TryParse(Request.Cookies[CookieUserId],out int parsedUserId);

                if (isValidUserId)
                {
                    UserIdVal = parsedUserId;
                }
            }

            TempData["TempUserId"]=UserIdVal;
            TempData["TempUserName"] = UsernameVal;

            return View();
        }

        // 4 -- Deleting the cookies info based on user request

        public IActionResult DeleteCookiesInfo()
        {
            try
            {
            CookieOptions cookieOptions = new CookieOptions()
            {
                Domain= "localhost",
                Path="/"
            };

            //Delete the cookies info from the broswer
            Response.Cookies.Delete(CookieUserName, cookieOptions);
            Response.Cookies.Delete(CookieUserId, cookieOptions);

            ViewBag.IsCookieInfoDeleted = true;

                }
            catch
            {
                ViewBag.IsCookieInfoDeleted = false;
            }
            return View();
        }

        

    }
}
