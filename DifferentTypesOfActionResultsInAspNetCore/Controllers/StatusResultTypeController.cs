using Microsoft.AspNetCore.Mvc;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class StatusResultTypeController : Controller
    {

        
        public IActionResult GetUserInfo(string userId)
        {
            string userIdVal = "S124578";

            if (userId != userIdVal)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            else
            {
                return Json("This user is Admin");
            }

        }

        public StatusCodeResult GetUserLogedInfo(string userId)
        {
            string userIdVal = "S124578";

            if (userId != userIdVal)
            {
                return StatusCode(403);
            }
           return StatusCode(200);
        }

        public IActionResult AreYouAdmin(string userId) { 
            string userIdVal = "S124578";

            if (userId != userIdVal)
            {
                return new UnauthorizedResult();
            }
            return StatusCode(200);
        }

        //With Helper method
        public IActionResult AreYouUser(string userId)
        {
            string userIdVal = "S124579";

            if (userId != userIdVal)
            {
                return Unauthorized(new { Message ="You are admin , not allowed to visit the user specific content"});
            }
            return StatusCode(200);
        }

        public NotFoundResult GetUserInfoByUserId(string userId)
        {

            return new NotFoundResult();
            //return  NotFound(); -- Helper method

        }
        public IActionResult GetUserInfoByUserName(string username)
        {

            //return new OkResult();

            var msg = new { Message ="User name is "+ username};
            return Ok(msg);
        }


    }
}
