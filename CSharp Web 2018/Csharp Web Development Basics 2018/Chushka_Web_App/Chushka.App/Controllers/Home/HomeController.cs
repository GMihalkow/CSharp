namespace Chushka.App.Controllers.Home
{
    using SIS.HTTP.Responses;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.DbContext.Users.FirstOrDefault(u => u.Username == this.User.Username);
            if (user == null)
            {
                return this.View();
            }

            return this.View(user);
        }
    }
}