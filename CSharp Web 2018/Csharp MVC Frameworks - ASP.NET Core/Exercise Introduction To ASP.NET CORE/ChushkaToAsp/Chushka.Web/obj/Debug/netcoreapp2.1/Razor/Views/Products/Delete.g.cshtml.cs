#pragma checksum "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90b872c763df3fc51e669e5c6aa37b445b1d112f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Delete), @"mvc.1.0.view", @"/Views/Products/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/Delete.cshtml", typeof(AspNetCore.Views_Products_Delete))]
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
#line 1 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\_ViewImports.cshtml"
using Chushka.Web;

#line default
#line hidden
#line 2 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\_ViewImports.cshtml"
using Chushka.Web.Models;

#line default
#line hidden
#line 1 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
using Chushka.Web.ViewModels.Products;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90b872c763df3fc51e669e5c6aa37b445b1d112f", @"/Views/Products/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28b1b7f90e180b0d87f381a53bb50c1d29a62730", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EditDeleteProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mx-auto half-width"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(77, 114, true);
            WriteLiteral("\r\n<main class=\"mt-3\">\r\n    <h1 class=\"text-center\">Delete Product</h1>\r\n    <hr class=\"bg-secondary hr-2\" />\r\n    ");
            EndContext();
            BeginContext(191, 2226, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a25b0a99c51423ea194c51920f15a06", async() => {
                BeginContext(284, 40, true);
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"Id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 324, "\"", 341, 1);
#line 8 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
WriteAttributeValue("", 332, Model.Id, 332, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(342, 198, true);
                WriteLiteral(" />\r\n        <div class=\"form-group\">\r\n            <label for=\"name\">Name</label>\r\n            <input disabled=\"disabled\" type=\"text\" class=\"form-control\" id=\"name\" placeholder=\"Name...\" name=\"name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 540, "\"", 559, 1);
#line 11 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
WriteAttributeValue("", 548, Model.Name, 548, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(560, 230, true);
                WriteLiteral(">\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label for=\"price\">Price</label>\r\n            <input disabled=\"disabled\" type=\"number\" step=\"any\" class=\"form-control\" id=\"price\" placeholder=\"Price...\" name=\"price\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 790, "\"", 810, 1);
#line 15 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
WriteAttributeValue("", 798, Model.Price, 798, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(811, 257, true);
                WriteLiteral(@">
        </div>
        <div class=""form-group"">
            <label for=""description"">Description</label>
            <textarea disabled=""disabled"" class=""form-control"" id=""description"" name=""description"" cols=""4"" rows=""3"" placeholder=""Description..."">");
                EndContext();
                BeginContext(1069, 17, false);
#line 19 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
                                                                                                                                             Write(Model.Description);

#line default
#line hidden
                EndContext();
                BeginContext(1086, 211, true);
                WriteLiteral("</textarea>\r\n        </div>\r\n        <h2 class=\"text-center\">Product Type</h2>\r\n        <hr class=\"bg-secondary hr-2 half-width\" />\r\n        <div class=\"channel-type-holder mt-4 d-flex justify-content-around\">\r\n");
                EndContext();
#line 24 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
               var types = new string[] { "Food", "Domestic", "Health", "Cosmetic", "Other" }; 

#line default
#line hidden
                BeginContext(1395, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 26 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
             foreach (var type in types)
            {

#line default
#line hidden
                BeginContext(1454, 86, true);
                WriteLiteral("                <div class=\"form-check form-check-inline\">\r\n                    <input");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 1540, "\"", 1556, 3);
                WriteAttributeValue("", 1545, "type(", 1545, 5, true);
#line 29 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
WriteAttributeValue("", 1550, type, 1550, 5, false);

#line default
#line hidden
                WriteAttributeValue("", 1555, ")", 1555, 1, true);
                EndWriteAttribute();
                BeginContext(1557, 70, true);
                WriteLiteral("\r\n                           type=\"radio\"\r\n                           ");
                EndContext();
#line 31 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
                            if (type == Model.ProductType.ToString())
                           {
                               

#line default
#line hidden
                BeginContext(1733, 31, false);
#line 33 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
                          Write(Html.Raw("checked=\"checked\""));

#line default
#line hidden
                EndContext();
#line 33 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
                                                               ;
                           }

#line default
#line hidden
                BeginContext(1797, 129, true);
                WriteLiteral("                           disabled=\"disabled\"\r\n                           name=\"productType\"\r\n                           value=\"");
                EndContext();
                BeginContext(1927, 4, false);
#line 37 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
                             Write(type);

#line default
#line hidden
                EndContext();
                BeginContext(1931, 62, true);
                WriteLiteral("\" />\r\n                    <label class=\"ml-1 form-check-label\"");
                EndContext();
                BeginWriteAttribute("for", " for=\"", 1993, "\"", 2010, 3);
                WriteAttributeValue("", 1999, "type(", 1999, 5, true);
#line 38 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
WriteAttributeValue("", 2004, type, 2004, 5, false);

#line default
#line hidden
                WriteAttributeValue("", 2009, ")", 2009, 1, true);
                EndWriteAttribute();
                BeginContext(2011, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(2013, 4, false);
#line 38 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
                                                                      Write(type);

#line default
#line hidden
                EndContext();
                BeginContext(2017, 34, true);
                WriteLiteral("</label>\r\n                </div>\r\n");
                EndContext();
#line 40 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Products\Delete.cshtml"
            }

#line default
#line hidden
                BeginContext(2066, 344, true);
                WriteLiteral(@"        </div>
        <hr class=""bg-secondary hr-2 half-width"" />
        <div class=""button-holder d-flex justify-content-center"">
            <button type=""submit"" class=""btn chushka-bg-color mr-5"">Delete</button>
            <button onclick=""window.history.back()"" class=""btn chushka-bg-color ml-5"">Cancel</button>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2417, 9, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditDeleteProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
