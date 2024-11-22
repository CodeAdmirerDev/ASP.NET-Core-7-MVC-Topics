using Microsoft.AspNetCore.Mvc;

namespace FiltersInASPNETCoreMVCApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewData["ErrorDetail"] = "The requested resource is not found. Please check the URL or contact the admin.";
                    ViewData["StatusCode"] = StatusCodes.Status404NotFound;
                    break;
            }

           return View("~/Views/Error/HandlingNonSuccessError.cshtml");
        }
    }
}
