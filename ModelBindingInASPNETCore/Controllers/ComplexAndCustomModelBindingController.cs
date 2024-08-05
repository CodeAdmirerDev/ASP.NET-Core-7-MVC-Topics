using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelBindingInASPNETCore.Models;

namespace ModelBindingInASPNETCore.Controllers
{
    public class ComplexAndCustomModelBindingController : Controller
    {
        [HttpGet("moviedetails/create")]
        // [Route("moviedetails/create")] same in attribute routing
        public ViewResult CreateMovie()
        {
            ViewBag.DirectorsList = Enum.GetValues(typeof(Directors)).Cast<Directors>().ToList();

            ViewBag.MovieTypeList = new List<SelectListItem>() {

                new SelectListItem {Text="Please select movie type", Value="0", Selected=true },
                new SelectListItem {Text="Horror", Value="1" },
                new SelectListItem {Text="Family", Value="2" },
                new SelectListItem {Text="Comedy", Value="3"},
                new SelectListItem {Text="SCFI", Value="4"},

             };

            ViewBag.CastList = new List<string> { "NTR", "PK", "RAM", "NBK" };

            //To get single value of enum ====> var SSRval = Directors.SSR;
            return View();
        }

        [HttpPost("moviedetails/create")]
        public IActionResult CreateMovie(MovieDetails movieDetails)
        {

            if (ModelState.IsValid)
            {
                TempData["SuccessMsg"] = "Movie created!";
                return RedirectToAction("SuccessView", "ModelBinding");
            }
            else
            {
                ViewBag.DirectorsList = Enum.GetValues(typeof(Directors)).Cast<Directors>().ToList();
                ViewBag.MovieTypeList = new List<SelectListItem>() {
                new SelectListItem {Text="Please select movie type", Value="0", Selected=true },
                new SelectListItem {Text="Horror", Value="1" },
                new SelectListItem {Text="Family", Value="2" },
                new SelectListItem {Text="Comedy", Value="3"},
                new SelectListItem {Text="SCFI", Value="4"},
             };

                ViewBag.CastList = new List<string> { "NTR", "PK", "RAM", "NBK" };

                //To get single value of enum ====> var SSRval = Directors.SSR;
                return View();
            }
        }
    }
}
