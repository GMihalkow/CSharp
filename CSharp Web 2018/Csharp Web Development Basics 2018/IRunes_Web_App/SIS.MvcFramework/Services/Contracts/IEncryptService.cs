namespace SIS.MvcFramework.Services.Contracts
{
    public interface IEncryptService
    {
        string Encrypt(string clearText, string encryprionKey);

        string Decrypt(string clearText, string encryprionKey);
    }
}
