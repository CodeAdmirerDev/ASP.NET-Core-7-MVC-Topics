using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomResultFilterApproachTwo : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            FileLogger.LogMessageIntoFile("CustomResultFilterApproachTwo: Executing custom result filter attribute after result execution.\n");

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            FileLogger.LogMessageIntoFile("CustomResultFilterApproachTwo: Executing custom result filter attribute before result execution.\n");

        }
    }
}
