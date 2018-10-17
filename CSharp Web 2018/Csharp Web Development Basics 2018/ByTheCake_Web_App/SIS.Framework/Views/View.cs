namespace SIS.Framework.Views
{
    using System.Collections.Generic;
    using System.IO;
    using SIS.Framework.ActionsResults.Contracts;

    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, Dictionary<string, object> viewData = null)
        {
            if (viewData == null)
                this.viewData = new Dictionary<string, object>();
            else
                this.viewData = viewData;

            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
        }

        private string ReadFile()
        {
            if (!File.Exists(this.fullyQualifiedTemplateName))
            {
                throw new FileNotFoundException($"View does not exist at {fullyQualifiedTemplateName}");
            }

            string result = File.ReadAllText(this.fullyQualifiedTemplateName);

            return result;
        }

        public string Render()
        {
            var fullHtml = this.ReadFile();

            fullHtml = RenderedHtml(fullHtml);

            return fullHtml;
        }

        private string RenderedHtml(string fullHtml)
        {
            foreach (var parameter in this.viewData)
            {
                fullHtml = fullHtml.Replace(parameter.Key, parameter.Value.ToString());
            }

            return fullHtml;
        }
    }
}
