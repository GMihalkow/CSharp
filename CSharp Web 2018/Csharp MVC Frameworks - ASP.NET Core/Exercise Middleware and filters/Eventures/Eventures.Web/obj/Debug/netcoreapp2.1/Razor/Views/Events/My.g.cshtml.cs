#pragma checksum "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\My.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39e919cad69782be59edfa6a12df59a3a611853c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_My), @"mvc.1.0.view", @"/Views/Events/My.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Events/My.cshtml", typeof(AspNetCore.Views_Events_My))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\_ViewImports.cshtml"
using Eventures.Web;

#line default
#line hidden
#line 2 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\_ViewImports.cshtml"
using Eventures.Web.Models;

#line default
#line hidden
#line 1 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\My.cshtml"
using Eventures.Web.ViewModels.Events;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39e919cad69782be59edfa6a12df59a3a611853c", @"/Views/Events/My.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3428bdf125acf975ca773013d873ea22e5318a61", @"/Views/_ViewImports.cshtml")]
    public class Views_Events_My : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyEventsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(81, 526, true);
            WriteLiteral(@"
<main class=""mt-5"">
    <h1 class=""text-center font-weight-bold"">My Events</h1>
    <hr class=""hr-eventure two-thirds-width bg-eventure"" />
    <table class=""table two-thirds-width mx-auto"">
        <thead>
            <tr>
                <th class=""col-lg-1"">#</th>
                <th class=""col-lg-3"">Name</th>
                <th class=""col-lg-2"">Start</th>
                <th class=""col-lg-2"">End</th>
                <th class=""col-lg-2"">Tickets</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 18 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\My.cshtml"
             for (int index = 0; index < Model.Count(); index++)
            {
                int realIndex = index + 1;
                MyEventsViewModel currentModel = Model.ElementAt(index);

#line default
#line hidden
            BeginContext(806, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(853, 9, false);
#line 23 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\My.cshtml"
                   Write(realIndex);

#line default
#line hidden
            EndContext();
            BeginContext(862, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(894, 22, false);
#line 24 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\My.cshtml"
                   Write(currentModel.EventName);

#line default
#line hidden
            EndContext();
            BeginContext(916, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(948, 53, false);
#line 25 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\My.cshtml"
                   Write(currentModel.StartDate.ToString("dd-MMM-yy hh:mm:ss"));

#line default
#line hidden
            EndContext();
            BeginContext(1001, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1033, 51, false);
#line 26 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\My.cshtml"
                   Write(currentModel.EndDate.ToString("dd-MMM-yy hh:mm:ss"));

#line default
#line hidden
            EndContext();
            BeginContext(1084, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1116, 22, false);
#line 27 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\My.cshtml"
                   Write(currentModel.MyTickets);

#line default
#line hidden
            EndContext();
            BeginContext(1138, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 29 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\My.cshtml"
            }

#line default
#line hidden
            BeginContext(1183, 100, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <hr class=\"hr-eventure two-thirds-width bg-eventure\" />\r\n</main>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyEventsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
