namespace TagHelpersInASPNETCoreMVC.Models.Services
{
    public class NewsService
    {
        private static readonly List<News> _news = new List<News>
        {
            new News
            {
                Id = 1,
                Title = "New Technology Breakthrough Revolutionizes AI",
                Content = "Scientists have developed a new algorithm that significantly improves the speed and accuracy of machine learning models.",
                PublishedDate = DateTime.Now.AddMinutes(55)
            },
            new News
            {
                Id = 2,
                Title = "Global Climate Summit: Nations Agree on New Targets",
                Content = "At the Global Climate Summit, world leaders have agreed on ambitious targets to reduce carbon emissions and combat climate change.",
                PublishedDate = DateTime.Now.AddMinutes(33)
            },
            new News
            {
                Id = 3,
                Title = "Major Stock Markets Hit Record Highs",
                Content = "Today, global stock markets reached new highs as investor confidence grew in the economic recovery post-pandemic.",
                PublishedDate = DateTime.Now.AddMinutes(24)
            },
            new News
            {
                Id = 4,
                Title = "Breakthrough in Renewable Energy: New Solar Panel Efficiency",
                Content = "Researchers have developed a new type of solar panel that increases energy efficiency by 20%, promising cheaper and cleaner energy.",
                PublishedDate = DateTime.Now.AddMinutes(15)
            }
        };

        // Simulating latest news fetch
        public List<News> GetLatestNews()
        {
            return _news.OrderByDescending(n => n.PublishedDate).ToList();
        }
    }
}
