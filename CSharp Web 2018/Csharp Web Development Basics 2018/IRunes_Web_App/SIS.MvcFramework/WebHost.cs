﻿namespace SIS.MvcFramework
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework.Contracts;
    using SIS.MvcFramework.Contracts.Services;
    using SIS.MvcFramework.Extenstions;
    using SIS.MvcFramework.Services;
    using SIS.MvcFramework.Services.Contracts;
    using SIS.WebServer;
    using SIS.WebServer.Results;
    using SIS.WebServer.Routing;

    public static class WebHost
    {
        public static void Start(IMvcApplication application)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            var dependencyContainer = new ServiceCollection();
            application.ConfigureServices(dependencyContainer);

            var serverRoutingTable = new ServerRoutingTable();
            AutoRegisterRoutes(serverRoutingTable, application, dependencyContainer);

            application.Configure();

            var server = new Server(8002, serverRoutingTable);
            server.Run();
        }

        private static void AutoRegisterRoutes(ServerRoutingTable routingTable, IMvcApplication application, IServiceCollection serviceCollection)
        {
            var controllers = application.GetType().Assembly.GetTypes()
                .Where(myType => myType.IsClass
                                 && !myType.IsAbstract
                                 && myType.IsSubclassOf(typeof(Controller)));
            foreach (var controller in controllers)
            {
                var getMethods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(
                    method => method.CustomAttributes.Any(
                        ca => ca.AttributeType.IsSubclassOf(typeof(HttpAttribute))));

                foreach (var methodInfo in getMethods)
                {
                    var httpAttribute = (HttpAttribute)methodInfo.GetCustomAttributes(true)
                        .FirstOrDefault(ca =>
                            ca.GetType().IsSubclassOf(typeof(HttpAttribute)));

                    if (httpAttribute == null)
                    {
                        continue;
                    }

                    routingTable.Add(httpAttribute.Method, httpAttribute.Path,
                        (request) => ExecuteAction(controller, methodInfo, request, serviceCollection));
                    Console.WriteLine($"Route registered: {controller.Name}.{methodInfo.Name} => {httpAttribute.Method} => {httpAttribute.Path}");
                }
            }
        }

        private static IHttpResponse ExecuteAction(Type controllerType,
            MethodInfo methodInfo, IHttpRequest request, IServiceCollection serviceCollection)
        {
            var controllerInstance = serviceCollection.CreateInstance(controllerType) as Controller;
            if (controllerInstance == null)
            {
                return new TextResult("Controller not found.",
                    HttpResponseStatusCode.InternalServerError);
            }

            controllerInstance.Request = request;
            controllerInstance.UserCookieService = serviceCollection.CreateInstance<UserCookieService>();

            var actionParameterObjects = GetActionParameterObjects(methodInfo, request, serviceCollection);
            var httpResponse = methodInfo.Invoke(controllerInstance, actionParameterObjects.ToArray()) as IHttpResponse;

            return httpResponse;
        }

        private static List<object> GetActionParameterObjects(MethodInfo methodInfo, IHttpRequest request,
         IServiceCollection serviceCollection)
        {
            var actionParameters = methodInfo.GetParameters();
            var actionParameterObjects = new List<object>();
            foreach (var actionParameter in actionParameters)
            {
                // TODO: Improve this check
                if (actionParameter.ParameterType.IsValueType ||
                    Type.GetTypeCode(actionParameter.ParameterType) == TypeCode.String)
                {
                    var stringValue = GetRequestData(request, actionParameter.Name);
                    actionParameterObjects.Add(TryParse(stringValue, actionParameter.ParameterType));
                }
                else
                {
                    var instance = serviceCollection.CreateInstance(actionParameter.ParameterType);
                    var properties = actionParameter.ParameterType.GetProperties();
                    foreach (var propertyInfo in properties)
                    {
                        // TODO: Support IEnumerable
                        var stringValue = GetRequestData(request, propertyInfo.Name);
                        var value = TryParse(stringValue, propertyInfo.PropertyType);

                        propertyInfo.SetMethod.Invoke(instance, new object[] { value });
                    }

                    actionParameterObjects.Add(instance);
                }
            }

            return actionParameterObjects;
        }

        private static string GetRequestData(IHttpRequest request, string key)
        {
            key = key.ToLower();
            string stringValue = null;
            if (request.FormData.Any(x => x.Key.ToLower() == key))
            {
                stringValue = StringExtensions.UrlDecode(request.FormData.First(x => x.Key.ToLower() == key).Value.ToString());
            }
            else if (request.QueryData.Any(x => x.Key.ToLower() == key))
            {
                stringValue = StringExtensions.UrlDecode(request.QueryData.First(x => x.Key.ToLower() == key).Value.ToString());
            }

            return stringValue;
        }

        private static object TryParse(string stringValue, Type type)
        {
            var typeCode = Type.GetTypeCode(type);
            object value = null;
            switch (typeCode)
            {
                case TypeCode.Int32:
                    if (int.TryParse(stringValue, out var intValue)) value = intValue;
                    break;
                case TypeCode.Char:
                    if (char.TryParse(stringValue, out var charValue)) value = charValue;
                    break;
                case TypeCode.Int64:
                    if (long.TryParse(stringValue, out var longValue)) value = longValue;
                    break;
                case TypeCode.Double:
                    if (double.TryParse(stringValue, out var doubleValue)) value = doubleValue;
                    break;
                case TypeCode.Decimal:
                    if (decimal.TryParse(stringValue, out var decimalValue)) value = decimalValue;
                    break;
                case TypeCode.DateTime:
                    if (DateTime.TryParse(stringValue, out var dateTimeValue)) value = dateTimeValue;
                    break;
                case TypeCode.String:
                    value = stringValue;
                    break;
            }

            return value;
        }
    }
}