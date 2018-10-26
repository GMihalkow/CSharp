namespace Torshia.App.Controllers.Home
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;
    using Torshia.App.Models;
    using Torshia.App.ViewModels.Users;

    public class HomeController : BaseController
    {
        [HttpGet("/Home/Index")]
        public IHttpResponse Index()
        {
            if (this.User != null)
            {
                User user = this.DbContext.Users.First(u => u.Username == this.User);
                var viewModel = user.To<PostRegisterViewModel>();
                viewModel.Role = user.Role;

                return this.View("/Home/LoggedIndex", viewModel, "_UserLayout");
            }
            else
            {
                return this.View("/Home/GuestIndex");
            }
        }

        [HttpGet("/")]
        public IHttpResponse RootIndex()
        {
            return this.Redirect("/Home/Index");
        }
    }
}