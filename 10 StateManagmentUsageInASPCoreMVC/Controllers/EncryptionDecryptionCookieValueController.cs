using Microsoft.AspNetCore.Mvc;
using StateManagementUsageInASPCoreMVC.Models;

namespace StateManagementUsageInASPCoreMVC.Controllers
{
    public class EncryptionDecryptionCookieValueController : Controller
    {
        const string CookieUserId = "UserId";
        const string CookieUserName = "UserName";

        private readonly ICustomCookieService _customCookieService;

        public EncryptionDecryptionCookieValueController(ICustomCookieService customCookieService)
        {
            _customCookieService = customCookieService;
        }



        // 1 -- Sending the encripted cookies info from server to client broswer

        public IActionResult EncryptedIndex()
        {
            CookieOptions options = new CookieOptions()
            {
                Domain = "localhost", //Here we need to set the domain for the cookie

                Path = "/",//It will available within the entire application

                Expires = DateTime.Now.AddDays(1),//It will expire in 1 day

                Secure = true,//These will ensure cookies will be sent over only in HTTPS(true)

                HttpOnly = true,//It will prevent the client-side scripts from accessing the cookie

                IsEssential = true,//It will represent the cookie is required to funcation in the application

            };

            try
            {
                //Here we are appending the encrypted cookies for UserId and UserName
                
                string encryptedUserId = _customCookieService.EncriptCookieValue("12345");
                
                Response.Cookies.Append(CookieUserId, encryptedUserId, options);

                string encryptedUserName = _customCookieService.EncriptCookieValue("DemoUser");

                Response.Cookies.Append(CookieUserName, encryptedUserName, options);
                ViewBag.IsSucess = true;
            }
            catch (Exception ex)
            {
                ViewBag.IsSucess = false;
                ViewBag.AnyError = $"Error occured during the encryption of cookie values : {ex.Message}";
            }

            return View();
        }

        // 2 -- Getting the encripted cookies info from client broswer to server then will decrypted to plain text

        public IActionResult DecryptedIndex()
        {
           
            try
            {
                //Here we are reading the encrypted cookies from Request object for UserId and UserName

                string? encryptedUserIdValue = Request.Cookies[CookieUserId];
                string? encryptedUserNameValue = Request.Cookies[CookieUserName];

                if (encryptedUserIdValue!=null)
                {
                    ViewBag.UserIdValue = _customCookieService.DecryptCookieValue(encryptedUserIdValue);
                }

                if (encryptedUserNameValue != null)
                {
                    ViewBag.UserNameValue = _customCookieService.DecryptCookieValue(encryptedUserNameValue);
                }

                ViewBag.IsSucess = true;
            }
            catch (Exception ex)
            {
                ViewBag.IsSucess = false;
                ViewBag.AnyError = $"Error occured during the decryption of cookie values : {ex.Message}";
            }

            return View();
        }

        public IActionResult DeleteCookiesInfo()
        {
            try
            {
                CookieOptions cookieOptions = new CookieOptions()
                {
                    Domain = "localhost",
                    Path = "/"
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
