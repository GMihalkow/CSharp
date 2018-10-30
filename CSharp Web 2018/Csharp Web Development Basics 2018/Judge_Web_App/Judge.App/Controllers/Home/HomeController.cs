namespace Judge.App.Controllers.Home
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View();
        } 

        [HttpGet("/")]
        public IHttpResponse Home()
        {
            return this.Redirect("/Home/Index");
        }
    }
}
