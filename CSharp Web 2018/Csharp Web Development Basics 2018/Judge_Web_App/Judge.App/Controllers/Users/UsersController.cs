namespace Judge.App.Controllers.Users
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

    public class UsersController : BaseController
    {
        public IHttpResponse Login()
        {
            return this.View();
        }

        public IHttpResponse Register()
        {
            return this.View();
        }
        
    }
}