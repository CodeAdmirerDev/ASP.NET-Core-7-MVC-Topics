using Microsoft.AspNetCore.Mvc;

namespace RoutingImplementationInASPDotnetCore.Controllers
{
    ////Using token controller at the Controller level using the Route Attribute
    //[Route("[controller]")]

    //Using controller and action tokens at the Controller level using the Route Attribute
    [Route("[controller]/[action]")]
    public class ShipmentTrackerController : Controller
    {
        //Using token action at the Action Method level using the Route Attribute
        [Route("/")] //This will make the Index Action method as the Default Action
        [Route("[action]")]
        public string Index()
        {
            return "Welcome to Shipment Tracking department.";
        }
        //Using token action at the Action Method level using the Route Attribute
        [Route("[action]")]
        public string ShipmentDetails(string location)
        {
            return "Welcome to Shipment Details department.";
        }

    }
}
