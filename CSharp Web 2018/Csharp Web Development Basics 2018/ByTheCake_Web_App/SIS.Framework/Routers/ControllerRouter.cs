namespace SIS.Framework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using SIS.Framework.ActionsResults.Base;
    using SIS.Framework.ActionsResults.Contracts;
    using SIS.Framework.Attributes.Methods.Base;
    using SIS.Framework.Controllers;
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using SIS.WebServer.Api.Contracts;
    using SIS.WebServer.Results;

    public class ControllerRouter : IHttpHandler
    {
        private const string UnsupportedActionMessage = "The view result is not supported.";

        private string layout = string.Empty;

        private IHttpRequest request;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.request = request;

            var isResourceRequest = this.IsResourceRequest(request);
            if (isResourceRequest)
            {
                return this.ReturnIfResource(request.Path);
            }

            var controllerName = string.Empty;
            var actionName = string.Empty;
            var requestMethod = request.RequestMethod.ToString();

            if (request.Url == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                var requestUrlSplit = request.Url.Split(
                    "/",
                    StringSplitOptions.RemoveEmptyEntries);

                controllerName = requestUrlSplit[0];
                actionName = requestUrlSplit[1];
            }

            var controller = this.GetController(controllerName, request);

            var action = this.GetMethod(requestMethod, controller, actionName);

            if (controller == null || action == null)
            {
                throw new NullReferenceException();
            }

            object[] actionParameters = this.MapActionParameters(action, request);
            IActionResult actionResult = this.InvokeAction(controller, action, actionParameters);

            return this.PrepareResponse(actionResult);
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParameters)
        {
            return (IActionResult)action.Invoke(controller, actionParameters);
        }

        private object[] MapActionParameters(MethodInfo action, IHttpRequest httpRequest)
        {
            ParameterInfo[] actionParametersInfo = action.GetParameters();
            object[] mappedActionParameters = new object[actionParametersInfo.Length];

            for (int index = 0; index < actionParametersInfo.Length; index++)
            {
                ParameterInfo currentParameterInfo = actionParametersInfo[index];

                if (currentParameterInfo.ParameterType.IsPrimitive ||
                    currentParameterInfo.ParameterType == typeof(string))
                {
                    mappedActionParameters[index] = ProcessPrimitiveParameter(currentParameterInfo, httpRequest);
                }
                else
                {
                    bool IsRequest = currentParameterInfo.ParameterType.FullName == typeof(IHttpRequest).ToString();

                    if (IsRequest)
                    {
                        mappedActionParameters[index] = httpRequest;
                    }
                    else
                    {
                        mappedActionParameters[index] = ProcessBindingModelParameters(currentParameterInfo, httpRequest);
                    }
                }
            }

            return mappedActionParameters;
        }

        private object ProcessBindingModelParameters(ParameterInfo param, IHttpRequest httpRequest)
        {
            Type bindingModelType = param.ParameterType;

            var bindingModelInstance = Activator.CreateInstance(bindingModelType);
            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var property in bindingModelProperties)
            {
                try
                {
                    object value = this.GetParameterFromRequestData(httpRequest, property.Name);
                    property.SetValue(bindingModelInstance, Convert.ChangeType(value, property.PropertyType));
                }
                catch
                {
                    Console.WriteLine($"The {property.Name} field could not be mapped.");
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }

        private object ProcessPrimitiveParameter(ParameterInfo param, IHttpRequest httpRequest)
        {
            object value = this.GetParameterFromRequestData(httpRequest, param.Name);
            return Convert.ChangeType(value, param.ParameterType);
        }

        private object GetParameterFromRequestData(IHttpRequest httpRequest, string paramName)
        {
            if (httpRequest.QueryData.ContainsKey(paramName)) return httpRequest.QueryData[paramName];
            if (httpRequest.FormData.ContainsKey(paramName)) return httpRequest.FormData[paramName];
            return null;
        }

        private bool IsResourceRequest(IHttpRequest httpRequest)
        {
            var requestPath = httpRequest.Path;
            if (requestPath.Contains('.'))
            {
                var requestPathExtension = requestPath
                    .Substring(requestPath.LastIndexOf('.'));
                return GlobalConstants.ResourceExtensions.Contains(requestPathExtension);
            }
            return false;
        }

        private IHttpResponse ReturnIfResource(string path)
        {
            path = $"/{Assembly.GetEntryAssembly().GetName(true).Name}/Resources/" + path;
            string fixedPath = WebUtility.UrlDecode(path);
            string fullPath = Path.GetFullPath(".." + fixedPath);

            if (File.Exists(fullPath))
            {
                byte[] resourceFileContent = File.ReadAllBytes(fullPath);
                return new InlineResourceResult(resourceFileContent, HttpResponseStatusCode.Ok);
            }
            else
            {
                return new HtmlResult("<h1>Error 404 Not Found!</h1>", HttpResponseStatusCode.NotFound);
            }
        }

        private IHttpResponse PrepareResponse(IActionResult actionResult)
        {
            string invocationResult = actionResult.Invoke();

            if ((request.Cookies.ContainsCookie("-auth") && request.Cookies.GetCookie("-auth").Expires < DateTime.UtcNow) || (!request.Cookies.ContainsCookie("-auth")))
            {
                layout = File.ReadAllText($"../" + Assembly.GetEntryAssembly().GetName().Name + "/Views/Layouts/_LoggedOutLayout.html");
            }
            else
            {
                layout = File.ReadAllText($"../" + Assembly.GetEntryAssembly().GetName().Name + "/Views/Layouts/_LoggedInLayout.html");
            }

            layout = layout.Replace("@Body", invocationResult);

            if (actionResult is IViewable)
            {
                var response = new HtmlResult(layout, HttpResponseStatusCode.Ok);

                if (this.request.Cookies.ContainsCookie("-auth"))
                {
                    response.AddCookie(this.request.Cookies.GetCookie("-auth"));
                }

                return response;
            }
            else if (actionResult is IRedirectable)
            {
                return new RedirectResult(layout);
            }

            throw new InvalidOperationException(UnsupportedActionMessage);
        }


        private MethodInfo GetMethod(
            string requestMethod,
            Controller controller,
            string methodName)
        {
            var methods = this
                .GetSuitableMethods(controller, methodName)
                .ToList();

            if (!methods.Any())
            {
                return null;
            }

            foreach (var method in methods)
            {
                var httpMethodAttributes = method
                    .GetCustomAttributes()
                    .Where(ca => ca is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>()
                    .ToList();

                if (!httpMethodAttributes.Any() &&
                    requestMethod.ToLower() == "get")
                {
                    return method;
                }

                foreach (var httpMethodAttribute in httpMethodAttributes)
                {
                    if (httpMethodAttribute.IsValid(requestMethod))
                    {
                        return method;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(
            Controller controller,
            string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(mi => mi.Name.ToLower() == actionName.ToLower());
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return null;
            }


            var fullyQualifiedControllerName = string.Format("{0}.{1}.{2}{3}, {0}",
                Assembly.GetEntryAssembly().GetName().Name,
                MvcContext.Get.ControllersFolder,
                controllerName,
                MvcContext.Get.ControllerSuffix);

            var controllerType = Type.GetType(fullyQualifiedControllerName);
            var controller = (Controller)Activator.CreateInstance(controllerType);
            return controller;
        }
    }
}
