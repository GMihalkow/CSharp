namespace SIS.MvcFramework.Contracts.Services
{
    using SIS.Services.MvcFramework;

    public interface IUserCookieService
    {
        string GetUserData(string cookieContent);
    }
}
