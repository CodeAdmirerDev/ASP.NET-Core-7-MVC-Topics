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

        [Produces("application/xml")]
        public IActionResult ProductDetails()
        {
            var productInfo = new { ProductId = 124, ProductName = "SmartPhone" };

            //var result= new ObjectResult(productInfo) { 

            //    StatusCode= 400, //HTTP status code for specifying result type
            //    ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
            //    {
            //        "application/xml"  // Content type of the response
            //    }
            //};

            //return result;
            return Ok(productInfo);
        }
    }


}
