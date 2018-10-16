namespace SIS.Framework.Services.Contracts
{
    public interface IUserCookieService
    {
        string Encrypt(string clearText, string encryprionKey);

        string Decrypt(string cipherText, string encryprionKey);

        string GetUserData(string cipherText, string encryptionKey);
    }
}
