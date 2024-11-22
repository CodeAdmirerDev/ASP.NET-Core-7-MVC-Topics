using Microsoft.AspNetCore.Mvc;

namespace TypesOfViewsInASPNETCore.Controllers
{
    public class RazorSyntaxAndViewUsageController : Controller
    {
        //Razor View engine example
        public ActionResult GetData()
        {

            return View();
        }

        public ActionResult ImplicitRazorExpressions()
        {

            return View();
        }
        public ActionResult ExplicitRazorExpressions()
        {

            return View();
        }
        public ActionResult UsingDirectives()
        {

            return View();
        }
        public ActionResult VariableDeclaration()
        {

            return View();
        }

        public ActionResult Comments()
        {

            return View();
        }
        public ActionResult ConditionalStatements()
        {

            return View();
        }

        

    }
}
