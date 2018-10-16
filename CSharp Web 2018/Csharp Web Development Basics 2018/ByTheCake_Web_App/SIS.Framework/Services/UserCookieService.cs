namespace SIS.Framework.Services
{
    using SIS.Framework.Services.Contracts;

    public class UserCookieService : IUserCookieService
    {
        private EncryptService encryptService;

        public UserCookieService()
        {
            encryptService = new EncryptService();
        }

        public string Decrypt(string cipherText, string encryprionKey)
        {
            return this.encryptService.Decrypt(cipherText, encryprionKey);
        }

        public string Encrypt(string clearText, string encryprionKey)
        {
            return this.encryptService.Encrypt(clearText, encryprionKey);
        }

        public string GetUserData(string cipherText, string encryptionKey)
        {
            string username = this.Decrypt(cipherText, encryptionKey);
            return username;
        }
    }
}