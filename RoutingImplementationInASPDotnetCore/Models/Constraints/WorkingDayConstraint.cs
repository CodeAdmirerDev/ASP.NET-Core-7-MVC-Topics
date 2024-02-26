
namespace RoutingImplementationInASPDotnetCore.Models.Constraints
{
    public class WorkingDayConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool responseVal = false;
            //validating the inputs
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (route == null)
            {
                throw new ArgumentNullException(nameof(route));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.TryGetValue(routeKey,out var routeValue))
            {
                string dateStringValue = routeValue as string;

              DateTime date=  DateTime.Parse(dateStringValue);

                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    responseVal= true;
                }
            }
            return responseVal;
        }
    }
}
