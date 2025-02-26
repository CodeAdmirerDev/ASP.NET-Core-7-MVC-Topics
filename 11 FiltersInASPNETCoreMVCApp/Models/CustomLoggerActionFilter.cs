using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Newtonsoft.Json;
using FiltersInASPNETCoreMVCApp.Models.Services;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomLoggerActionFilter : ActionFilterAttribute
    {
        private Stopwatch _stopwatchTimer;
        private readonly ILoggerService _loggerService;
        public CustomLoggerActionFilter(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //It will start the timer
            _stopwatchTimer = Stopwatch.StartNew();
            var actionName = context.ActionDescriptor.RouteValues["action"];
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var parameters = JsonConvert.SerializeObject(context.ActionArguments);

            string message = $" Statrting Action Method {actionName} in Controller {controllerName} with parameters {parameters} started at {System.DateTime.Now}";

            _loggerService.LogInformation(message);

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatchTimer.Stop();

            var actionName = context.ActionDescriptor.RouteValues["action"];
            var controllerName = context.ActionDescriptor.RouteValues["controller"];

            string message = $" Ended Action Method {actionName} in Controller {controllerName} in {_stopwatchTimer.ElapsedMilliseconds} ms";

            _loggerService.LogInformation(message);
            base.OnActionExecuted(context);
        }


    }
}
