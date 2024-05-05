using Microsoft.AspNetCore.Mvc;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class RedirectResultTypeController : Controller
    {

        public RedirectToActionResult CallToRedirectCountHistory()
        {

            return RedirectToAction("RedirectCountHistory", "RedirectResultType",new { userName = "Anusha", noOfHits=120 });

        }
        public string RedirectCountHistory(string userName, int noOfHits)
        {

            return "Hi " + userName + ", Your recent Route count history is :" + noOfHits;
        }

        public RedirectToActionResult Index()
        {

            return RedirectToAction("OpenGoogle");

        }

        public RedirectToActionResult CallOtherControllerActionMethod()
        {

            return RedirectToAction("Index","Home");

        }

        public RedirectResult OpenGoogle()
        {
            return new RedirectResult("https://www.google.co.in/");
        }

        public RedirectResult OpenGitHub()
        {
            return new RedirectResult("https://github.com/CodeAdmirerDev");
        }

        public RedirectToRouteResult CallNewRoute()
        {
            return RedirectToRoute("DetailsOfRedirectToRouteResult");
        }

        public string RouteDetails()
        {
            return "Here we have used the RedirectToRouteResult to call the specific route";
        }

      
    }


}
