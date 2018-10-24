namespace SIS.MvcFramework.Services
{
    public interface IUserCookieService
    {
        string GetUserCookie(string userName);

        string GetUserData(string cookieContent);

        string EncryptString(string clearText, string keyString);

        string DecryptString(string cipherText, string keyString);
    }
}
