using Microsoft.AspNetCore.Mvc;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class EmptyResultTypeController : Controller
    {
        public IActionResult DeleteProduct(int productId)
        {
           
            // You have deleted Product from Product DB
            //And you want to send confirmation to the User but not willing to send any data as a response
            //Then you can use the Empty result as a return type

            return new EmptyResult(); // Return HTTP 200 as status code and empty response
        }

        public IActionResult DeleteEmployee(int empId)
        {

            // You have deleted Product from Product DB
            //And you want to send confirmation to the User but not willing to send any data as a response
            //Then you can use the Empty result as a return type

            return NoContent(); // Return HTTP 204(No Content) status code and empty response
        }
    }

}
