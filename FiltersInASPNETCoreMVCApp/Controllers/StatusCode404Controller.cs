using FiltersInASPNETCoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltersInASPNETCoreMVCApp.Controllers
{
    public class StatusCode404Controller : Controller
    {
        List<GeoLocation> GeoLocations = null;

        public StatusCode404Controller() {
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

      
    }
}
