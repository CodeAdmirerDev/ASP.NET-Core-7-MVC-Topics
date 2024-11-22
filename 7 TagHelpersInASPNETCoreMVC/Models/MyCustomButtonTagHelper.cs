using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersInASPNETCoreMVC.Models
{
    // Specify that this TagHelper will target HTML elements with the name "custom-button"
    [HtmlTargetElement("custom-button")]
    // Inherits from TagHelper to create custom tag helper functionality.
    public class MyCustomButtonTagHelper : TagHelper
    {
        // Define a public property to store the text inside the button, with a default value "Click Me"
        public string Text { get; set; } = "Click Me";
        // Define a public property to store the button type (e.g., "submit", "button"), default value is "button"
        public string ButtonType { get; set; } = "button";
        // Define a public property to store the CSS class for the button, with a default value "btn-primary"
        public string ButtonClass { get; set; } = "btn-primary";
        // Override the Process method to define the custom processing logic of the tag helper, which gets called when the TagHelper runs
        // TagHelperContext context: Provides information about the tag being processed, such as the tag's attributes and ID.
        // TagHelperOutput output: Controls the final output that is rendered, including modifying the tag name, attributes, and inner content of the tag being processed.
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Set the output tag to be a "button" element, effectively rendering <button> in the final HTML
            output.TagName = "button";
            // Add the "type" attribute to the button element, using the value specified in the ButtonType property
            output.Attributes.SetAttribute("type", ButtonType);
            // Add the "class" attribute to the button, combining "btn" with the value in the ButtonClass property
            output.Attributes.SetAttribute("class", $"btn {ButtonClass}");
            // Set the content inside the button, using the value from the Text property
            output.Content.SetContent(Text);
        }
    }
}
