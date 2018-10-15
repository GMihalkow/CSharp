namespace SIS.MvcFramework.Services
{
    using SIS.MvcFramework.Contracts.Services;
    using SIS.MvcFramework.Logger.Contacts;
    using SIS.Services.MvcFramework;

    public class UserCookieService : IUserCookieService
    {
        private readonly ILogger logger;

        public UserCookieService()
        {

        }

        public UserCookieService(ILogger logger) : this()
        {
            this.logger = logger;
        }

        private EncryptService EncryptService => new EncryptService();

        public string EncryptString(string text, string keyString)
        {
            string result = EncryptService.Encrypt(text, keyString);

            return result;
        }

        public string DecryptString(string cipherText, string keyString)
        {
            string result = EncryptService.Decrypt(cipherText, keyString);

            return result;
        }

        public string GetUserData(string cookieContent, string EncryptKey)
        {
            this.logger.Log("GetUserData()" + cookieContent);
            string username = DecryptString(cookieContent, EncryptKey);

            return username;
        }
    }
}
