using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class DataTransformationActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ViewResult viewResult)
            {
                if(viewResult.Model is CustomModel model)
                {
                   // Implement your custom logic here
                    model.DataTransform();
                }

            }
            base.OnActionExecuted(context);
        }

    }
}
