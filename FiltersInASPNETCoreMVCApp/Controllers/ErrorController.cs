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

                case 400:
                    return View("~/Views/Shared/SyntaxOrClientSide.cshtml");
                case 401:
                    return View("~/Views/Shared/UnauthorizedError.cshtml");
                case 403:
                    return View("~/Views/Shared/ForbiddenRequest.cshtml");
                case 404:
                    ViewData["ErrorDetail"] = "The requested resource is not found. Please check the URL or contact the admin.";
                    ViewData["StatusCode"] = StatusCodes.Status404NotFound;
                    return View("~/Views/Error/HandlingNonSuccessError.cshtml");
                case 500:
                    return View("~/Views/Shared/InvernalServerError.cshtml");
                case 503:
                    return View("~/Views/Shared/ServiceUnAvailable.cshtml");
                default:
                    return View("~/Views/Shared/Error.cshtml");
            }

           
        }
    }
}
