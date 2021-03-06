﻿namespace SIS.Framework.Controllers
{
    using System.Runtime.CompilerServices;
    using SIS.Framework.ActionsResults;
    using SIS.Framework.ActionsResults.Contracts;
    using SIS.Framework.Services;
    using SIS.Framework.Utilities;
    using SIS.Framework.Views;
    using SIS.Framework.Services.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using System.Collections.Generic;
    using SIS.Framework.Models;

    public abstract class Controller
    {
        protected const string EncryptKey = "db69b189-4f79-4fc0-aa81-94dc9182f761";

        protected const string AuthenticationCookieKey = "-auth.cakes";

        protected HashService hashService;

        protected IUserCookieService cookieService;

        protected Controller()
        {
            this.Response = new HttpResponse();
            this.hashService = new HashService();
            this.cookieService = new UserCookieService();
            this.Model = new ViewModel();
        }


        public IHttpResponse Response { get; set; }

        public IHttpRequest Request { get; set; }

        public Model ModelState { get; } = new Model();

        protected ViewModel Model { get; }

        protected IViewable View([CallerMemberName] string viewName = "", Dictionary<string, object> parameters = null)
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            var viewFullyQualifiedName = ControllerUtilities
                .GetViewFullyQualifiedName(controllerName, viewName);

            var view = new View(viewFullyQualifiedName, parameters);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
            => new RedirectResult(redirectUrl);
    }
}
