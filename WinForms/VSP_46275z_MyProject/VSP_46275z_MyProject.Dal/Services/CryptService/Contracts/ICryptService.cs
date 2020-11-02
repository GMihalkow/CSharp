namespace VSP_46275z_MyProject.Dal.Services.CryptService.Contracts
{
    public interface ICryptService
    {
        string Encrypt(string text);

        string Decrypt(string text);
    }
}