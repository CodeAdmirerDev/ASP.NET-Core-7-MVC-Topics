namespace TagHelpersInASPNETCoreMVC.Models.Services
{
    public class BlogPostService
    {
        private static readonly List<BlogPost> _blogPosts = new()
        {
            new BlogPost { Id = 1, Title = "First Post", Summary = "This is the first post summary.", PublishedOn = DateTime.Now.AddDays(-10) },
            new BlogPost { Id = 2, Title = "Second Post", Summary = "This is the second post summary.", PublishedOn = DateTime.Now.AddDays(-9) },
            new BlogPost { Id = 3, Title = "Third Post", Summary = "This is the third post summary.", PublishedOn = DateTime.Now.AddDays(-6) },
            new BlogPost { Id = 4, Title = "Fourth Post", Summary = "This is the fourth post summary.", PublishedOn = DateTime.Now.AddDays(-3) },
            new BlogPost { Id = 5, Title = "Fifth Post", Summary = "This is the fifth post summary.", PublishedOn = DateTime.Now.AddDays(-2) }
        };

        public async Task<List<BlogPost>> GetRecentPostsAsync(int count)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            var recentPosts = _blogPosts
                .OrderByDescending(post => post.PublishedOn)
                .Take(count).ToList();
            return recentPosts;
        }
    }
}
