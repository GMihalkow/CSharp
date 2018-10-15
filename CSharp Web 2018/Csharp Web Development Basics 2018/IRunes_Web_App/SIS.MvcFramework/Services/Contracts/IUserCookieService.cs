namespace SIS.MvcFramework.Contracts.Services
{
    using SIS.Services.MvcFramework;

    public interface IUserCookieService
    {
        string GetUserData(string cookieContent, string EncryptKey);

        string EncryptString(string text, string keyString);

        string DecryptString(string cipherText, string keyString);
    }
}