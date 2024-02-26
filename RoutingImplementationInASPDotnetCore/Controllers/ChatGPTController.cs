using Microsoft.AspNetCore.Mvc;

namespace RoutingImplementationInASPDotnetCore.Controllers
{
    public class ChatGPTController : Controller
    {
        public IActionResult Search()
        {

            ViewData["ChatGPTSearch"] = "Welcome to ChatGPT, You can search any info.";
            return View();
        }

        public IActionResult IsWokringDay(string enterTheDate)
        {
            TempData["IsWokringDay"] = "It is working Day!";
            return View();
        }

        public IActionResult InfoAboutChatGPT(string version)
        {

            ViewBag.Version = version;
            if (version=="3")
            {
                TempData["VersionInfo"] = "It's a free ChatGpt version :";

            }
            else if (version=="4")
            {
                TempData["VersionInfo"] = "It's a paid ChatGpt version :";

            }
            else
            {
                TempData["VersionInfo"] = "This ChatGpt version is not available and Version number is :";

            }
            return View();
        }
    }
}
