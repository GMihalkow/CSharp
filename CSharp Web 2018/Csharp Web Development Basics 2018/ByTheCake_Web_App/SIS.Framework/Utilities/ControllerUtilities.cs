using SIS.Framework.Controllers;
using System.IO;
using System.Reflection;

namespace SIS.Framework.Utilities
{
    public static class ControllerUtilities
    {
        public static string GetControllerName(object controller) =>
            controller
                .GetType()
                .Name
                .Replace(MvcContext.Get.ControllerSuffix, string.Empty);

        public static string GetViewFullyQualifiedName(
            string controllerName,
            string viewName) =>
            string.Format("../" + Assembly.GetEntryAssembly().GetName().Name + "/{0}/{1}/{2}.html",
                MvcContext.Get.ViewsFolder,
                controllerName,
                viewName);
    }
}
