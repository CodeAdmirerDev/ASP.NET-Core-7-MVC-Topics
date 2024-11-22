using Microsoft.AspNetCore.Mvc;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class ObjectResultTypeController : Controller
    {
        public IActionResult Index()
        {
            var productInfo = new { ProductId=124, ProductName="SmartPhone"};

            //Return an ObjectResult with JSON serialization
           //return new ObjectResult(productInfo);

            //Or we can also send the response like below
            return Ok(productInfo);

        }

        public IActionResult CoderDetails()
        {

            var person = new { FirstName = "Suri", LastName = "L", Age = 28 };
            var result = new ObjectResult(person)
            {
                StatusCode = 200, // HTTP status code
                ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
                {
                    "application/json" // Content type(s)
                }
            };
            return result;
        }

    public IActionResult GetCoderDetails()
    {
        var person = new { FirstName = "Suri", LastName = "L", Age = 28 };
        // Return a 200 OK response with JSON serialization
        return Ok(person);
    }

        public IActionResult GetCoderDetailsMultipleReturnTypes()
        {
            var person = new { FirstName = "Pranaya", LastName = "Rout", Age = 30 };
            var result = new ObjectResult(person)
            {
                StatusCode = 201, // Created status code
                ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
                {
                    "application/json", // JSON content type
                    "application/xml" // XML content type
                }
            };
            return result;
        }


    }

}
