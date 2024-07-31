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


        //FromForm
        [HttpPost]
        public IActionResult UpdateMovieDetails([FromForm] Movie movie)
        {

            return View();
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


    }
}
