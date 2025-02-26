
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Create your custom authorization logic here 
            if (!IsAuthorized(context.HttpContext.User))
            {
                // If the user is not authorized then set the result and it will redirect to login page
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new { controller = "Home", action = "Login" }
                    
                    ));
            }

        }

        private bool IsAuthorized(ClaimsPrincipal user)
        {
            // Check the user is authorized or not
            // We can implement our custom logic here
            // check the user roles , claims , polices or any other custom logic
            // Return true if the user is authorized , otherwise false
            return false; // it is for just test purpose
        }
    }
}
