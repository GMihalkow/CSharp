#pragma checksum "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd28c5912b1a150c588157346dd544fe9a78dbc1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Packages_Pending), @"mvc.1.0.view", @"/Views/Packages/Pending.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Packages/Pending.cshtml", typeof(AspNetCore.Views_Packages_Pending))]
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
#line 1 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\_ViewImports.cshtml"
using PandaToAsp;

#line default
#line hidden
#line 2 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\_ViewImports.cshtml"
using PandaToAsp.Models;

#line default
#line hidden
#line 1 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml"
using Panda.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd28c5912b1a150c588157346dd544fe9a78dbc1", @"/Views/Packages/Pending.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e93aacc8c8cb6571a779298540b9a9dd27ec8eaf", @"/Views/_ViewImports.cshtml")]
    public class Views_Packages_Pending : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 979, true);
            WriteLiteral(@"
<main class=""mt-3"">
    <h1 class=""text-center"">Pending Shipment</h1>
    <hr class=""hr-2 bg-panda"">
    <div class=""d-flex justify-content-between"">
        <table class=""table table-hover table-bordered"">
            <thead>
                <tr class=""row"">
                    <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>#</h3></th>
                    <th scope=""col"" class=""col-lg-4 d-flex justify-content-center""><h3>Description</h3></th>
                    <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>Weight</h3></th>
                    <th scope=""col"" class=""col-lg-3 d-flex justify-content-center""><h3>Shipping Address</h3></th>
                    <th scope=""col"" class=""col-lg-2 d-flex justify-content-center""><h3>Recipient</h3></th>
                    <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>Actions</h3></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 19 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml"
                  int index = 0;

#line default
#line hidden
            BeginContext(1036, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 20 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml"
                 foreach (var item in Model)
                {
                    { index++; }

#line default
#line hidden
            BeginContext(1135, 117, true);
            WriteLiteral("                    <tr class=\"row\">\r\n                        <td class=\"col-lg-1 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1253, 5, false);
#line 24 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml"
                                                                          Write(index);

#line default
#line hidden
            EndContext();
            BeginContext(1258, 91, true);
            WriteLiteral("</h5></td>\r\n                        <td class=\"col-lg-4 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1350, 16, false);
#line 25 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml"
                                                                          Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1366, 91, true);
            WriteLiteral("</h5></td>\r\n                        <td class=\"col-lg-1 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1458, 11, false);
#line 26 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml"
                                                                          Write(item.Weight);

#line default
#line hidden
            EndContext();
            BeginContext(1469, 94, true);
            WriteLiteral(" KG</h5></td>\r\n                        <td class=\"col-lg-3 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1564, 20, false);
#line 27 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml"
                                                                          Write(item.ShippingAddress);

#line default
#line hidden
            EndContext();
            BeginContext(1584, 91, true);
            WriteLiteral("</h5></td>\r\n                        <td class=\"col-lg-2 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1676, 23, false);
#line 28 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml"
                                                                          Write(item.Recipient.Username);

#line default
#line hidden
            EndContext();
            BeginContext(1699, 119, true);
            WriteLiteral("</h5></td>\r\n                        <td class=\"col-lg-1 d-flex justify-content-center\">\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1818, "\"", 1851, 2);
            WriteAttributeValue("", 1825, "/packages/ship?id=", 1825, 18, true);
#line 30 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml"
WriteAttributeValue("", 1843, item.Id, 1843, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1852, 101, true);
            WriteLiteral(" class=\"btn bg-panda text-white\">Ship</a>\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 33 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Pending.cshtml"
                }

#line default
#line hidden
            BeginContext(1972, 59, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
