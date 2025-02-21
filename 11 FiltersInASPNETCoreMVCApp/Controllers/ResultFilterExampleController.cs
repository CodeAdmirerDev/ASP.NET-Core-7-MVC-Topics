using FiltersInASPNETCoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace FiltersInASPNETCoreMVCApp.Controllers
{
    [CustomResultFilter]
    public class ResultFilterExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [CustomResultFilterApproachOne]
        public string ResultFilterApproachOne()
        {
            return "Please check the log file : ResultFilterLog.txt ";
        }

        //private void LogMessageIntoFile(string logMessage)
        //{
        //    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "FilterLogs", "ResultFilterLog.txt");

        //    File.AppendAllText(filePath, logMessage);
        //}
    }
}
