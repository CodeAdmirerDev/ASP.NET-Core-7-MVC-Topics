using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingInASPNETCore.Models;

namespace ModelBindingInASPNETCore.Controllers
{
    public class ModelBindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult WithOutModelBindingForm(IFormCollection formData)
        {
            var MovieTitleValue = formData["MovieTitle"].ToString();
            var HeroNameValue = formData["HeroName"].ToString();

            if (MovieTitleValue != null && HeroNameValue != null)
            {
                return Json("Movie data is stored Successfully! The Movie title is " + MovieTitleValue + " , Hero name is " + HeroNameValue);

            }
            else
            {
                return Json("Movie data is not stored ! ");

            }

        }

        public IActionResult ModelBindingIndex()
        {
            return View();
        }
        [HttpPost]
        public JsonResult WithModelBindingForm(Movie movieDetails)
        {
            if (movieDetails != null)
            {

                if (ModelState.IsValid)
                {
                    return Json("Movie data is stored Successfully!");
                }
                else
                {
                    return Json("Movie data is not valid !");

                }
            }
            else
            {
                return Json("Movie data is not stored ! ");

            }

        }


        //FromBody
        [HttpPost]
        public IActionResult CreateMovieDetails([FromBody] Movie movie) {

            return View();
        }

        /**
                        //FromForm
        ModelBindingFromFormIndex is Get request, it will load the form 
        Once user click the submit button it will redirect to UpdateMovieDetails POST method
        **/
        public IActionResult ModelBindingFromFormIndex()
        {
            return View();
        }

        //FromForm using object type
        [HttpPost]
        public IActionResult ModelBindingFromFormIndex([FromForm] Movie movie)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMsg"] = "From Form object method executed successfully!";
                return RedirectToAction("SuccessView");
            }
            return View(movie);
        }


        //FromForm using primitive type and to execute the below method update the  asp-action value with this method name 
        [HttpPost]
        public IActionResult ModelBindingFromFormPrimitiveIndex([FromForm] string MovieName, [FromForm] string MovieCollection)
        {
            if (MovieName!=null && MovieCollection!=null)
            {

                TempData["SuccessMsg"] = "From Form primitive method executed successfully!";
                return RedirectToAction("SuccessView");

            }
            return Json("Facing issue with Form data");
        }

        //FromForm using Name property type and to execute the below method update the  asp-action value with this method name 
        [HttpPost]
        public IActionResult ModelBindingFromFormNamePropertyIndex([FromForm(Name = "MovieName")] string MovieName, [FromForm(Name = "MovieCollection")] string MovieCollection, [FromForm] IFormFile movieImage)
        {
            if (MovieName != null && MovieCollection != null)
            {

                TempData["SuccessMsg"] = "From Form Name Property method executed successfully!";
                return RedirectToAction("SuccessView");

            }
            return Json("Facing issue with Form data");

        }


            //FromQuery
            public JsonResult GetMovieDetailsByName([FromQuery] string movieName)
        {
            if (movieName != null)
            {
                return Json("Movie details are : kalki");

            }
            else
            {
                return Json("Movie data is not found!");
            }
        }

        //FromRoute
        [HttpGet("{heroName}")]
        public IActionResult GetMoveByHeroName([FromRoute] string heroName)
        {
            return View();

        }

        //FromHeader
        public IActionResult VerifyUser([FromHeader(Name ="User-Agent")] string userAgent)
        {
            return View();

        }


        //SuccessView
        public IActionResult SuccessView()
        {
            return View();
        }

    }
}
