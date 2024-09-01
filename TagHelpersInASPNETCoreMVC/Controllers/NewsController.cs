using Microsoft.AspNetCore.Mvc;
using TagHelpersInASPNETCoreMVC.Models.Services;

namespace TagHelpersInASPNETCoreMVC.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult LatestNews()
        {
            NewsService _newsService = new NewsService();
            var latestNews = _newsService.GetLatestNews();
            return View(latestNews);
        }
    }
}
