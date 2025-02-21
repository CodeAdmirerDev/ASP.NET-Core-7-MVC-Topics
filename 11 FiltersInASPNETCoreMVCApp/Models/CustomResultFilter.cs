using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomResultFilter : ResultFilterAttribute
    {

        public CustomResultFilter() { }

        private Stopwatch _stopwatchTimer;

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //It will start the timer
            _stopwatchTimer = Stopwatch.StartNew();
            
            //Adding the header before executing the result
            context.HttpContext.Response.Headers.Append("X-Pre-Execute", "This header is set before execution");

            //Based on condition we can also add the content before executingt the result

            if (context.HttpContext.Request.Query.ContainsKey("manager") && 
                context.Result is ViewResult viewResult )
            {
                context.Result = new ViewResult
                {
                    ViewName = "ManagerView",
                    ViewData = viewResult.ViewData,
                    TempData = viewResult.TempData
                };
            }

            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _stopwatchTimer.Stop();

            var methodName = context.ActionDescriptor.DisplayName;
            var executionTime = _stopwatchTimer?.ElapsedMilliseconds;
            var filterType = context.Filters.GetType().Name;
            var resultType = context.Result.GetType().Name;

            //Below log will helpful to understand the method execution process
            Debug.WriteLine($"Method name: '{methodName}' executed in '{executionTime}' ms, resulting in '{resultType}'");
            base.OnResultExecuted(context);
        }
    }
}
