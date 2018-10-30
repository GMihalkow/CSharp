namespace Judge.App.Controllers.Home
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.DbContext.Users.FirstOrDefault(u => u.FullName == this.User.Username);

            if(user == null)
            {
                return this.View();
            }
            else
            {
                return this.View(user);
            }
        } 

        [HttpGet("/")]
        public IHttpResponse Home()
        {
            return this.Redirect("/Home/Index");
        }
    }
}
