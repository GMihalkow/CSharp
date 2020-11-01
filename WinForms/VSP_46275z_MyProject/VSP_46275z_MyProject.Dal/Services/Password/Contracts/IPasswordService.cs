namespace VSP_46275z_MyProject.Dal.Services.Password.Contracts
{
    public interface IPasswordService
    {
        string Hash(string text);
    }
}