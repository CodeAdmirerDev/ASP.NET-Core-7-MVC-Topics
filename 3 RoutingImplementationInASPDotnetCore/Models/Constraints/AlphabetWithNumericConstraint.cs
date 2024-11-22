
using System.Text.RegularExpressions;

namespace RoutingImplementationInASPDotnetCore.Models.Constraints
{
    public class AlphabetWithNumericConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {

            //validating the inputs
            if (httpContext==null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (route==null)
            {
                throw new ArgumentNullException(nameof(route));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.TryGetValue(routeKey,out object? routeValue))
            {
                var userInput = Convert.ToString(routeValue);
                string pattern = @"^[a-zA-Z0-9]+$";

                    if(Regex.IsMatch(userInput ?? string.Empty, pattern)){

                    return true;
                    }
                    else
                    {
                    return false;
                    }
                
            }

            return false;
        }
    }
}
