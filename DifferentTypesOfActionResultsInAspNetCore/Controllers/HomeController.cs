using DifferentTypesOfActionResultsInAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var homeIndexViewModel = new HomeIndexViewModel()
            {
                Id = 1,
                Name = "Home",
            };
            return View(homeIndexViewModel);
        }
    }
    public class HomeIndexViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

}
