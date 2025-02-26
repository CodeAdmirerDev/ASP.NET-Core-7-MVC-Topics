using FiltersInASPNETCoreMVCApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiltersInASPNETCoreMVCApp.Controllers
{
   
    public class AuthorizationFilterExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous] // it will allow anonymous access to the below action method
        public string Test()
        {
            return "I am using the authorization filter";
        }

        public string TermsAndConditions()
        {
            return "Please observe T&C before signing";
        }

        [Authorize] // it will requires authentication for the below action method
        public string DashBoardResults()
        {
            return "This year revenue is 80%";
        }

        [TypeFilter(typeof(CustomAuthorizationFilter))] // it will apply the custom authorization filter to the below action method
        public string EmpSalData()
        {
            return "This year revenue is 80%";
        }

    }
}
