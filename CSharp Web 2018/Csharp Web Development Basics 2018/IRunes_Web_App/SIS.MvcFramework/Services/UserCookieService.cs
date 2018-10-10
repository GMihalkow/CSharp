namespace SIS.MvcFramework.Services
{
    using SIS.MvcFramework.Contracts.Services;
    using SIS.Services.MvcFramework;

    public class UserCookieService : IUserCookieService
    {
        public const string EncryptKey = "186fd62b-5806-4b7b-8f76-3b04ad02bee3";

        public UserCookieService()
        {
        }

        private static EncryptService EncryptService => new EncryptService();

        public static string EncryptString(string text, string keyString)
        {
            string result = EncryptService.Encrypt(text, keyString);

            return result;
        }

        public static string DecryptString(string cipherText, string keyString)
        {
            string result = EncryptService.Decrypt(cipherText, keyString);

            return result;
        }

        public string GetUserData(string cookieContent)
        {
            string username = DecryptString(cookieContent, EncryptKey);

            return username;
        }
    }
}
