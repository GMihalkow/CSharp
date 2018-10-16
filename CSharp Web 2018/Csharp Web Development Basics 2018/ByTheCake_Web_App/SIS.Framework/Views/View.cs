using System.Collections.Generic;
using System.IO;
using SIS.Framework.ActionsResults.Contracts;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        private readonly Dictionary<string, string> parameters;

        public View(string fullyQualifiedTemplateName, Dictionary<string, string> parameters = null)
        {
            if (parameters == null)
                this.parameters = new Dictionary<string, string>();
            else
                this.parameters = parameters;

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

            foreach (var parameter in this.parameters)
            {
                fullHtml = fullHtml.Replace(parameter.Key, parameter.Value);
            }

            return fullHtml;
        }
    }
}
