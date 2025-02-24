using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Reflection;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomResultFilterApproachOne : ResultFilterAttribute
    {

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            FileLogger.LogMessageIntoFile("CustomResultFilterApproachOne: Executing custom result filter attribute before result execution.\n");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {

            var methodName = context.ActionDescriptor.DisplayName;
            var filterType = context.Filters.GetType().Name;
            var resultType = context.Result.GetType().Name;

            //Below log will helpful to understand the method execution process
            FileLogger.LogMessageIntoFile($" CustomResultFilterApproachOne : Here is the few more info : Method name: '{methodName}' executed, resulting in '{resultType}'. \n");

            FileLogger.LogMessageIntoFile("CustomResultFilterApproachOne: Executing custom result filter attribute after result execution.\n");
        }

       }
}
