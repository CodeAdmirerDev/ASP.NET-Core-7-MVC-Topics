using FiltersInASPNETCoreMVCApp.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomErrorHandlerActionFilter : ExceptionFilterAttribute
    {

        private readonly ILoggerService _loggerService;

        public CustomErrorHandlerActionFilter(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public override void OnException(ExceptionContext context)
        {
            string errorMessage = context.Exception.Message;

            // Log the exception
            _loggerService.LogInformation("Custom Exception logging started");

            _loggerService.LogInformation($"An error occurred in {context.ActionDescriptor.DisplayName} , Error message is :{errorMessage} ");

            // Set up the view result with error details
            context.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(), context.ModelState)
        {
                    // Pass the exception message for debugging (avoid in production) it is optional 
            { "ErrorDetail", context.Exception.Message }
            ,{ "StatusCode", Microsoft.AspNetCore.Http.StatusCodes.Status502BadGateway }
        }
            };

            // Mark the exception as handled
            context.ExceptionHandled = true;
            _loggerService.LogInformation("Custom Exception logging completed");
        }
    }
}
