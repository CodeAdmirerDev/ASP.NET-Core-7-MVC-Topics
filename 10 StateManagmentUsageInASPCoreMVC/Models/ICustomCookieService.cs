namespace StateManagementUsageInASPCoreMVC.Models
{
    public interface ICustomCookieService
    {
        public string EncriptCookieValue(string cookieValue);
        public string DecryptCookieValue(string encryptedCookieValue);
    }
}
