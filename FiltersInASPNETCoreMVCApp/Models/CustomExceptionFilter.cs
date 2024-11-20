using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {

            _logger = logger;
        }


        public void OnException(ExceptionContext context)
        {
            // Log the exception
            _logger.LogError(context.Exception, "Custom Exception logging started");
            _logger.LogError(context.Exception, "An error occurred while processing your request. Please try again");

            // Set up the view result with error details
            context.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(), context.ModelState)
        {
            { "ErrorDetail", context.Exception.Message } // Pass the exception message for debugging (avoid in production)
            ,{ "StatusCode", StatusCodes.Status502BadGateway }
        }
            };

            // Mark the exception as handled
            context.ExceptionHandled = true;
            _logger.LogError(context.Exception, "Custom Exception logging completed");
        }

    }
}
