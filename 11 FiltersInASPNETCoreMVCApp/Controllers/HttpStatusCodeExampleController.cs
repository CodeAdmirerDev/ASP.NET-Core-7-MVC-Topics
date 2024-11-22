using FiltersInASPNETCoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltersInASPNETCoreMVCApp.Controllers
{
    public class HttpStatusCodeExampleController : Controller
    {
        List<GeoLocation> GeoLocations = null;

        public HttpStatusCodeExampleController() {
            GeoLocations = new List<GeoLocation>() { 
           
           new GeoLocation { GeoCodeId=1, Latitude=100.1, Longitude=102.5},
           new GeoLocation { GeoCodeId=2, Latitude=101.1, Longitude=103.5},
           new GeoLocation { GeoCodeId=3, Latitude=102.1, Longitude=104.5},
           new GeoLocation { GeoCodeId=4, Latitude=103.1, Longitude=105.5}
           
            };

        }
        public IActionResult Index()
        {
            return View();
        }
       
        public ViewResult GetGeoLocationInfo(int geoLocationId)
        {
            GeoLocation? geoLocation = GeoLocations.Where(geoloaction => geoloaction.GeoCodeId == geoLocationId).FirstOrDefault();

            if (geoLocation == null) {

                Response.StatusCode = 404;
                return View("GeoLoactionNotFound", geoLocationId);

            }

            return View(geoLocation);
        }

        public IActionResult GeoLoactionNotFound()
        {
            return View();
        }

        //400 -- The server could not understand the request. 
        public IActionResult RaiseBadRequest()
        {
            var isItContainInvalidSyntaxOrClientError = true;

            if (isItContainInvalidSyntaxOrClientError)
            {
                return new StatusCodeResult(400);
            }
            //If everythings looks good ,Then display the view
            return View();

        }

        //401 -- Authentication is required to access the resource.
        public IActionResult RaiseUnauthorizedRequest()
        {
            var isNotAuthenticated = true;

            if (isNotAuthenticated)
            {
                return new StatusCodeResult(401);
            }
            //If everythings looks good ,Then display the view
            return View();

        }

        //403 -- The server refuses to fulfill the request.     
        public IActionResult RaiseForbiddenRequest()
        {
            var isUserNotHaveTheAccessToDashBoardPage = true;

            if (isUserNotHaveTheAccessToDashBoardPage)
            {
                return new StatusCodeResult(403);
            }
            //If everythings looks good ,Then display the view
            return View();

        }

        //404 -- The requested resource could not be found
        public IActionResult RaiseNotFoundRequest()
        {
            var isResourceNotFound = true;

            if (isResourceNotFound)
            {
                return new StatusCodeResult(404);
            }
            //If everythings looks good ,Then display the view
            return View();

        }

        //500 -- A generic error occurred on the server.
        public IActionResult RaiseInternalServerRequest()
        {
            try
            {
                throw new Exception("Some thing went wrong, please try again later!");
                return View();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }

        }

        //503 -- The server is not ready to handle the request.    
        public IActionResult RaiseServiceUnAvailableRequest()
        {
            var isServiceUnavailable = true;

            if (isServiceUnavailable)
            {
                return new StatusCodeResult(503);
            }
            //If everythings looks good ,Then display the view
            return View();

        }


    }
}
