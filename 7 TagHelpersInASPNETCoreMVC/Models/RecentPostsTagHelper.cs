namespace TagHelpersInASPNETCoreMVC.Models
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Threading.Tasks;
    using TagHelpersInASPNETCoreMVC.Models.Services;

    [HtmlTargetElement("recent-posts")]
    public class RecentPostsTagHelper : TagHelper
    {
        // Attribute to specify the number of recent posts to display
        [HtmlAttributeName("count")]
        public int Count { get; set; } = 5; // Default to 5 if not specified
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Simulate a service that fetches the recent blog posts
            BlogPostService blogPostService = new BlogPostService();
            var posts = await blogPostService.GetRecentPostsAsync(Count);
            // Set the output tag to render as a div with Bootstrap classes for better styling
            output.TagName = "div"; // Render the tag as a div
            output.Attributes.SetAttribute("class", "container mt-4"); // Container class to wrap the content
            // Start building the content using Bootstrap components
            var content = "<div class='row'>"; // Start a new Bootstrap row for vertical alignment
            foreach (var post in posts)
            {
                content += $@"
                    <div class='col-12 mb-4'>
                        <div class='card border-primary shadow'>
                            <div class='card-header bg-primary text-white'>
                                <h5 class='card-title mb-0'>{post.Title}</h5>
                            </div>
                            <div class='card-body'>
                                <p class='card-text'>{post.Summary}</p>
                                <p class='card-text'><small class='text-muted'>Published on: {post.PublishedOn.ToShortDateString()}</small></p>
                            </div>
                            <div class='card-footer text-right'>
                                <a href='#' class='btn btn-outline-primary btn-sm'>Read More</a>
                            </div>
                        </div>
                    </div>";
            }
            content += "</div>"; // Close the Bootstrap row
            // Add the constructed content to the TagHelper output
            output.Content.SetHtmlContent(content);
        }
    }
}
