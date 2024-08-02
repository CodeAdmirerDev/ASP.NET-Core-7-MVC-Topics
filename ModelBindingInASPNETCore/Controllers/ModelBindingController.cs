using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingInASPNETCore.Models;

namespace ModelBindingInASPNETCore.Controllers
{
    public class ModelBindingController : Controller
    {
        List<Movie> _movies;

        public ModelBindingController() {

            _movies = new List<Movie>() { 
            
                new Movie(){HeroName="NTR",MovieName="Devara",MovieCollection=100000},
                new Movie(){HeroName="NTR",MovieName="NKPM",MovieCollection=50000},

                new Movie(){HeroName="Nani",MovieName="MCA",MovieCollection=50000},

                new Movie(){HeroName="Chiru",MovieName="K150",MovieCollection=200000},
            };
        }

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


       
        /**
        //FromForm start
        
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

        // End of FromForm



        //FromQuery start

        //FromQuery using object type
        public IActionResult SearchMovieInfo([FromQuery] UserSearchCriteria searchCriteria)
        {
            List<Movie> filteredMovie = new List<Movie>();

            if (searchCriteria != null)
            {

                if(!string.IsNullOrEmpty(searchCriteria.MovieName)  && !string.IsNullOrEmpty(searchCriteria.HeroName))
                {
                    filteredMovie = _movies.Where(m => m.MovieName.ToUpper().Equals(searchCriteria.MovieName.ToUpper()) && m.HeroName.ToUpper().Equals(searchCriteria.HeroName.ToUpper())).ToList();
                }
                else if (!string.IsNullOrEmpty(searchCriteria.MovieName))
                {
                    filteredMovie = _movies.Where(m => m.MovieName.ToUpper().Equals(searchCriteria.MovieName.ToUpper())).ToList();
                }
                else if (!string.IsNullOrEmpty(searchCriteria.HeroName))
                {
                    filteredMovie = _movies.Where(m => m.HeroName.ToUpper().Equals(searchCriteria.HeroName.ToUpper())).ToList();
                }
            }

            return Ok(filteredMovie);
        }
        //FromForm using primitive type 
        // Eg: https://localhost:7086/ModelBinding/SearchMovieInfoByPrimitiveType?HeroName=NTR&MovieName=Devara
        public IActionResult SearchMovieInfoByPrimitiveType([FromQuery] string HeroName, [FromQuery] string MovieName)
        {
            List<Movie> filteredMovie = new List<Movie>();

            if (ModelState.IsValid)
            {

                if (!string.IsNullOrEmpty(MovieName) && !string.IsNullOrEmpty(HeroName))
                {
                    filteredMovie = _movies.Where(m => m.MovieName.ToUpper().Equals(MovieName.ToUpper()) && m.HeroName.ToUpper().Equals(HeroName.ToUpper())).ToList();
                }
                else if (!string.IsNullOrEmpty(MovieName))
                {
                    filteredMovie = _movies.Where(m => m.MovieName.ToUpper().Equals(MovieName.ToUpper())).ToList();
                }
                else if (!string.IsNullOrEmpty(HeroName))
                {
                    filteredMovie = _movies.Where(m => m.HeroName.ToUpper().Equals(HeroName.ToUpper())).ToList();
                }
            }

            return Ok(filteredMovie);
        }

        //FromQuery using Name property type 
        // Eg: https://localhost:7086/ModelBinding/SearchMovieInfoByNamePropertyType?Hval=NTR&Mval=Devara
        public IActionResult SearchMovieInfoByNamePropertyType([FromQuery(Name ="Hval")] string HeroName, [FromQuery(Name ="Mval")] string MovieName)
        {
            List<Movie> filteredMovie = new List<Movie>();

            if (ModelState.IsValid)
            {

                if (!string.IsNullOrEmpty(MovieName) && !string.IsNullOrEmpty(HeroName))
                {
                    filteredMovie = _movies.Where(m => m.MovieName.ToUpper().Equals(MovieName.ToUpper()) && m.HeroName.ToUpper().Equals(HeroName.ToUpper())).ToList();
                }
                else if (!string.IsNullOrEmpty(MovieName))
                {
                    filteredMovie = _movies.Where(m => m.MovieName.ToUpper().Equals(MovieName.ToUpper())).ToList();
                }
                else if (!string.IsNullOrEmpty(HeroName))
                {
                    filteredMovie = _movies.Where(m => m.HeroName.ToUpper().Equals(HeroName.ToUpper())).ToList();
                }
            }

            return Ok(filteredMovie);
        }
        
        // End of FromQuery


        //FromRoute start

        // Eg: https://localhost:7086/MovieDetails/Devara/getdetails
        [HttpGet]
        [Route("MovieDetails/{moviename}/getdetails")]
        public IActionResult GetMoveByMovieName([FromRoute] string moviename)
        {
            var moveDetails = _movies.FirstOrDefault(m=> m.MovieName.ToUpper().Equals(moviename.ToUpper()));

            if (moveDetails==null) {

                return NotFound();
            }
            return Ok(moveDetails);

        }

        //FromRoute using Name property type
        //Eg https://localhost:7086/HeroDetails/NTR/getdetails
        [HttpGet]
        [Route("HeroDetails/{hName}/{mName}/getdetails")]
        public IActionResult GetMoveByHeroName([FromRoute(Name = "hName")] string heroname, [FromRoute(Name = "mName")]  string moviename)
        {
            var moveDetails = _movies.FirstOrDefault(m => m.HeroName.ToUpper().Equals(heroname.ToUpper()));

            if (moveDetails == null)
            {

                return NotFound();
            }
            return Ok(moveDetails);

        }
        
        // End of FromRoute

        //FromHeader start
        public IActionResult VerifyUser([FromHeader(Name ="User-Agent")] string userAgent)
        {
            return View();

        }

        [HttpGet]
        public IActionResult GetLocalizedContent([FromHeader(Name = "Accept-Language")] string language)
        {
            return View();
        }

        // End of FromHeader



        //FromBody
        // Call this method using any tool like Postman
        /**
          
        Method type : Post
        URL : https://localhost:7086/ModelBinding/CreateMovieDetails
        Request body as Json : 

        {
         "MovieName" :"Devara",
         "HeroName" :"NTR",
         "MovieCollection" :"522"
        }
         * */
        [HttpPost]
        public IActionResult CreateMovieDetails([FromBody] Movie movie)
        {

            return View();
        }

        // End of FromBody

        //SuccessView
        public IActionResult SuccessView()
        {
            return View();
        }

    }
}
