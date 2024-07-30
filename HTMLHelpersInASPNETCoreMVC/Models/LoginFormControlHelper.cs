using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HTMLHelpersInASPNETCoreMVC.Models
{
    public static class LoginFormControlHelper
    {

        public static IHtmlContent CustomLoginInputFormValidation(this IHtmlHelper htmlHelper, string labelName, string modelPropertyName)
        {
            var loginFormHtml = $@"
            <div class='form-group'>
<form>
            <label for'{modelPropertyName}'>{labelName}</label>
            <input type='text' class='form-control' required id='{modelPropertyName}' name='{modelPropertyName}' asp-for='{modelPropertyName}' />
<span asp-validation-for='{modelPropertyName}' class='text-danger'> </span>
<input type='submit' value='Submit'>
</form>
</div>

";

            return new HtmlString(loginFormHtml);

        }

    }
}
