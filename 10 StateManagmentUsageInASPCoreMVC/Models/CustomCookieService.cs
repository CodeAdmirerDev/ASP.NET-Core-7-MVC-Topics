using Microsoft.AspNetCore.DataProtection;

namespace StateManagementUsageInASPCoreMVC.Models
{
    public class CustomCookieService : ICustomCookieService
    {

        //Declare a private field to hold the IDataProtector instance
        private readonly IDataProtector _dataProtector;

        //In constructor that accepts an IDataProtectionProvider and creates a data protector
        public CustomCookieService(IDataProtectionProvider dataProtectionProvider)
        {
            // Intialize _dataProtector with an IDataProtector instance created using IDataProtectionProvider

            // The "StateManagementUsageInASPCoreMVC" string is a purpose to used for data protection
            // By using the above string is unique per data protection conect to maintain the security

            _dataProtector = dataProtectionProvider.CreateProtector("StateManagementUsageInASPCoreMVC");
        }


        //Thid metod will encrypt the cookievalue
        public string EncriptCookieValue(string cookieValue)
        {

            try
            {
                // Encrypt the provided cookievalue using IDataProtector insatnce _dataProtector
                //It will return the encrypted cookievalue as a string
                return _dataProtector.Protect(cookieValue);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while encrypting the cookie value",ex);
            }

        }

        //Thid metod will decrypt the encryptedCookieValue
        public string DecryptCookieValue(string encryptedCookieValue)
        {

            try
            {
                // Decrypt the provided encryptedCookieValue using IDataProtector insatnce _dataProtector
                //It will return the decrypted cookievalue as a string
                return _dataProtector.Unprotect(encryptedCookieValue);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while decrypting the cookie value", ex);
            }

        }

    }
}
