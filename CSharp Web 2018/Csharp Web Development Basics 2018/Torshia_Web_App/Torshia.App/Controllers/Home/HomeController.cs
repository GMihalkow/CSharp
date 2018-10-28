namespace Torshia.App.Controllers.Home
{
    using SIS.HTTP.Responses;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.DbContext.Users.FirstOrDefault(u => u.Username == this.User.Username);
            return this.View(user);
        }
        
        public IHttpResponse RootIndex()
        {
            return this.Redirect("/Home/Index");
        }
    }
}