using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Reflection;

namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomResultFilterApproachOne : ResultFilterAttribute
    {

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            LogMessageIntoFile("Executing custom result filter attribute before result execution.\n");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {

            var methodName = context.ActionDescriptor.DisplayName;
            var filterType = context.Filters.GetType().Name;
            var resultType = context.Result.GetType().Name;

            //Below log will helpful to understand the method execution process
            LogMessageIntoFile($" Here is the few more info : Method name: '{methodName}' executed, resulting in '{resultType}'. \n");

            LogMessageIntoFile("Executing custom result filter attribute after result execution.\n");
        }

        private void LogMessageIntoFile(string logMessage)
        {

           string folderPath = Path.Combine(Directory.GetCurrentDirectory()+ "/FilterLogs"); // Specify the folder path
            string filePath = Path.Combine(folderPath, "ResultFilerLog.txt"); // Specify the file name

            // Check if the folder exists, if not, create it
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Folder created.");
            }

            // Check if the file exists, if not, create it
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose(); // Create and close the file immediately
                Console.WriteLine("File created.");
            }

            // Append text to the file
            File.AppendAllText(filePath, logMessage + Environment.NewLine); // Append the text with a new line
            Console.WriteLine("Text appended to file.");
        }
    }
}
