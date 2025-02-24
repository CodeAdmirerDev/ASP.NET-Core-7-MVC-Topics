namespace FiltersInASPNETCoreMVCApp.Models
{
    public class FileLogger
    {
        public static void LogMessageIntoFile(string logMessage)
        {

            string folderPath = Path.Combine(Directory.GetCurrentDirectory() + "/FilterLogs"); // Specify the folder path
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
