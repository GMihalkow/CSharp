#pragma checksum "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d322b6244315d6399cfa7e5292692e798c7955f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_All), @"mvc.1.0.view", @"/Views/Events/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Events/All.cshtml", typeof(AspNetCore.Views_Events_All))]
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
#line 1 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
using Eventures.Web.ViewModels.Events;

#line default
#line hidden
#line 2 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
using Eventures.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d322b6244315d6399cfa7e5292692e798c7955f6", @"/Views/Events/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3428bdf125acf975ca773013d873ea22e5318a61", @"/Views/_ViewImports.cshtml")]
    public class Views_Events_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventsOnPageViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-group"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Events", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "All", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn bg-eventure text-black"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(98, 148, true);
            WriteLiteral("\r\n<main class=\"mt-5\">\r\n    <h1 class=\"text-center font-weight-bold\">All Events</h1>\r\n\r\n    <hr class=\"hr-eventure two-thirds-width bg-eventure\" />\r\n");
            EndContext();
#line 9 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
     if (Model.Events.Count() == 0)
    {
        

#line default
#line hidden
            BeginContext(299, 89, false);
#line 11 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
   Write(await Html.PartialAsync("Error", new ErrorViewModel { ErrorMessage = "No events found."}));

#line default
#line hidden
            EndContext();
#line 11 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                                                                                                  
    }
    else
    {


#line default
#line hidden
            BeginContext(416, 425, true);
            WriteLiteral(@"        <table class=""table two-thirds-width mx-auto"">
            <thead>
                <tr>
                    <th class=""col-lg-1"">#</th>
                    <th class=""col-lg-3"">Name</th>
                    <th class=""col-lg-2"">Start</th>
                    <th class=""col-lg-2"">End</th>
                    <th class=""col-lg-3"">Actions</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 27 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                 for (int index = 0; index < Model.Events.Length; index++)
                {
                    int realIndex = index + 1 + Model.Start;
                    Event currentEvent = Model.Events[index];

#line default
#line hidden
            BeginContext(1061, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(1116, 9, false);
#line 32 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                       Write(realIndex);

#line default
#line hidden
            EndContext();
            BeginContext(1125, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1161, 17, false);
#line 33 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                       Write(currentEvent.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1178, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1214, 49, false);
#line 34 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                       Write(currentEvent.Start.ToString("dd-MMM-yy hh:mm:ss"));

#line default
#line hidden
            EndContext();
            BeginContext(1263, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1299, 47, false);
#line 35 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                       Write(currentEvent.End.ToString("dd-MMM-yy hh:mm:ss"));

#line default
#line hidden
            EndContext();
            BeginContext(1346, 65, true);
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1411, 620, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "894e70d96cee44c38db5ee3f80aa21cf", async() => {
                BeginContext(1491, 34, true);
                WriteLiteral("\r\n                                ");
                EndContext();
                BeginContext(1525, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd7e4218302c4783a66cd9657cf0f516", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 38 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1585, 85, true);
                WriteLiteral("\r\n                                <input hidden=\"hidden\" type=\"text\" name=\"eventName\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1670, "\"", 1696, 1);
#line 39 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
WriteAttributeValue("", 1678, currentEvent.Name, 1678, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1697, 327, true);
                WriteLiteral(@" />
                                <label for=""ticketsCount"" class=""font-weight-bold"">Tickets</label>
                                <input class=""form-group"" type=""number"" name=""ticketsCount"" id=""ticketsCount"" />
                                <button class=""btn bg-eventure"">Order</button>
                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2031, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 46 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                }

#line default
#line hidden
            BeginContext(2110, 42, true);
            WriteLiteral("            </tbody>\r\n\r\n        </table>\r\n");
            EndContext();
#line 50 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
    }

#line default
#line hidden
            BeginContext(2159, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 52 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
      
        int pageNumber = 0;
    

#line default
#line hidden
            BeginContext(2205, 31, true);
            WriteLiteral("    <div class=\"text-center\">\r\n");
            EndContext();
#line 56 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
         for (int index = 0; index < Model.TotalEventsCount; index++)
        {
            if (index == 0)
            {
                pageNumber++;

#line default
#line hidden
            BeginContext(2393, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(2409, 119, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c1a0b76da0d4010839355e21fa57ec1", async() => {
                BeginContext(2514, 10, false);
#line 61 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                                                                                                                   Write(pageNumber);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-start", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 61 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                                                                                                    WriteLiteral(index);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["start"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-start", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["start"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2528, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 62 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                continue;
            }
            if ((index + 1) % 10 == 0)
            {
                pageNumber++;
                int nextStep = index + 1;

#line default
#line hidden
            BeginContext(2701, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(2717, 122, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a495ec8edf524569a016affeeb234a69", async() => {
                BeginContext(2825, 10, false);
#line 68 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                                                                                                                      Write(pageNumber);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-start", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 68 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
                                                                                                    WriteLiteral(nextStep);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["start"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-start", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["start"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2839, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 69 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\Eventures\Eventures.Web\Views\Events\All.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(2867, 73, true);
            WriteLiteral("    </div>\r\n    <hr class=\"hr-eventure two-thirds-width bg-eventure\" />\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2962, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2972, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dfa4daf5ce8a43cfa4e7673370bfae91", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3016, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            BeginContext(3025, 9, true);
            WriteLiteral("\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventsOnPageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
