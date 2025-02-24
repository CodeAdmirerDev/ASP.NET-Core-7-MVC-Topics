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

        [ServiceFilter(typeof(CustomResultFilterApproachTwo))]
        public string ResultFilterApproachTwo()
        {
            return "Please check the log file : ResultFilterLog.txt ";
        }

        [ServiceFilter(typeof(CustomResultFilterApproachThree))]
        public string ResultFilterApproachThree()
        {
            return "Please check the log file : ResultFilterLog.txt ";
        }

        // This action will return a JSON response, which could be compressed

        [HttpGet("ResultFilterExample/GetData")]
        public IActionResult GetData()
        {
            var data = new
            {
                Message = "This is a sample data to test compression",
                Timestamp = DateTime.UtcNow
            };

            Response.ContentType = "application/json";
            return Json(data); // This will be compressed if the client supports gzip/deflate
        }

        // This action will return a large HTML page
        public IActionResult LargePage()
        {
            var htmlContent = "<html><body>" +
                              "<h1>Large Page</h1>" +
                              string.Join("", Enumerable.Range(0, 1000).Select(i => $"<p>Paragraph {i}</p>")) +
                              "</body></html>";

            return Content(htmlContent, "text/html"); // This HTML content could also be compressed
        }


        //private void LogMessageIntoFile(string logMessage)
        //{
        //    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "FilterLogs", "ResultFilterLog.txt");

        //    File.AppendAllText(filePath, logMessage);
        //}
    }
}
