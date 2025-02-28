using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomValidationActionFilter : IActionFilter
    {
       

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("userAccountModel", out var modelValue) && modelValue is CustomModel model ) {

                //Validate name
                if (string.IsNullOrEmpty(model.Name))
                {
                    context.ModelState.AddModelError(nameof(model.Name), "Name is required");
                }
                // Validate name length
                if (model.Name !=null && model.Name.Length < 5)
                {
                    context.ModelState.AddModelError("Name", "Name must be at least 5 characters long");
                }

                //Validate Address
                if (string.IsNullOrEmpty(model.Address))
                {
                    context.ModelState.AddModelError("Address", "Address is required");
                }

                // Handle the invalid model state
                if (!context.ModelState.IsValid)
                {
                    context.Result = new ViewResult
                    {
                        ViewName = context.RouteData.Values["action"].ToString(), // To get the current action name

                        ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState)
                        {
                            Model = context.ActionArguments.FirstOrDefault(arg => arg.Value is CustomModel).Value
                        }
                    };

                }
            }

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes
        }
    }
}
