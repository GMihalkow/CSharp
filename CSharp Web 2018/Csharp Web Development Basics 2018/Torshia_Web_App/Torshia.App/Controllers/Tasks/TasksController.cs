namespace Torshia.App.Controllers.Tasks
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Linq;
    using Torshia.App.Models;
    using Torshia.App.Models.Enums;

    public class TasksController : BaseController
    {
        [HttpGet("/Tasks/Create")]
        public IHttpResponse Create()
        {
            User user = null;

            if(this.User == null)
            {
                return this.BadRequestError("404 Page Not Found", 0);
            }

            user = 
                this.DbContext
                .Users
                .First(u => u.Username == this.User);

            if(user.Role != Role.Admin)
            {
                return this.BadRequestError("404 Page Not Found", 1);
            }

            return this.View("Tasks/Create", user, "_UserLayout");
        }
    }
}