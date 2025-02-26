namespace FiltersInASPNETCoreMVCApp.Models.Services
{
    public class LoggerService : ILoggerService
    {
        public void LogInformation(string message)
        {
            FileLogger.LogMessageIntoFile(message);
        }
    }
}
