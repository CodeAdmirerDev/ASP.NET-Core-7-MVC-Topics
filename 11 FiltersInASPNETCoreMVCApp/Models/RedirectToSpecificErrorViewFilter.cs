using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class RedirectToSpecificErrorViewFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public RedirectToSpecificErrorViewFilter(ILogger<CustomExceptionFilter> logger)
        {

            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            // Log the exception
            _logger.LogError(context.Exception, "Redirect To Specific ErrorView Filter logging started");
            _logger.LogError(context.Exception, "An error occurred while processing your request. Please try again");

            context.Result = new ViewResult
            {
                ViewName = "UnauthorizedError",
            };

            // Mark the exception as handled
            context.ExceptionHandled = true;
            _logger.LogError(context.Exception, "Custom Exception logging completed");

        }
    }
}
