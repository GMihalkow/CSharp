#pragma checksum "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01a60373c59147e8028395abc64ad1aac8b6efc2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Receipts_Index), @"mvc.1.0.view", @"/Views/Receipts/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Receipts/Index.cshtml", typeof(AspNetCore.Views_Receipts_Index))]
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
#line 1 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"
using Panda.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a60373c59147e8028395abc64ad1aac8b6efc2", @"/Views/Receipts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e93aacc8c8cb6571a779298540b9a9dd27ec8eaf", @"/Views/_ViewImports.cshtml")]
    public class Views_Receipts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Receipt[]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(43, 855, true);
            WriteLiteral(@"
<main class=""mt-3"">
    <h1 class=""text-center"">My Receipts</h1>
    <hr class=""hr-2 bg-panda"">
    <div class=""d-flex justify-content-between"">
        <table class=""table table-hover table-bordered"">
            <thead>
                <tr class=""row"">
                    <th scope=""col"" class=""col-lg-5 d-flex justify-content-center""><h3>Id</h3></th>
                    <th scope=""col"" class=""col-lg-2 d-flex justify-content-center""><h3>Fee</h3></th>
                    <th scope=""col"" class=""col-lg-2 d-flex justify-content-center""><h3>Issued On</h3></th>
                    <th scope=""col"" class=""col-lg-2 d-flex justify-content-center""><h3>Recipient</h3></th>
                    <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>Actions</h3></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 20 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"
                   int index = 0; 

#line default
#line hidden
            BeginContext(935, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 21 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"
                   decimal Total = 0;

#line default
#line hidden
            BeginContext(975, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 22 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"
                  string totalF2 = null;

#line default
#line hidden
            BeginContext(1018, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 23 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"
                 foreach (var item in Model)
                {
                    { index++; }
                    { Total = item.Fee * 2.67m; }
                    { totalF2 = $"{Total:f2}"; }


#line default
#line hidden
            BeginContext(1220, 129, true);
            WriteLiteral("                    <tr class=\"row\">\r\n                        <th scope=\"row\" class=\"col-lg-5 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1350, 7, false);
#line 30 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"
                                                                                      Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1357, 92, true);
            WriteLiteral("</h5></th>\r\n                        <td class=\"col-lg-2 d-flex justify-content-center\"><h5>$");
            EndContext();
            BeginContext(1450, 7, false);
#line 31 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"
                                                                           Write(totalF2);

#line default
#line hidden
            EndContext();
            BeginContext(1457, 91, true);
            WriteLiteral("</h5></td>\r\n                        <td class=\"col-lg-2 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1549, 27, false);
#line 32 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"
                                                                          Write(item.IssuedOn.ToString("d"));

#line default
#line hidden
            EndContext();
            BeginContext(1576, 91, true);
            WriteLiteral("</h5></td>\r\n                        <td class=\"col-lg-2 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1668, 23, false);
#line 33 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"
                                                                          Write(item.Recipient.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1691, 119, true);
            WriteLiteral("</h5></td>\r\n                        <td class=\"col-lg-1 d-flex justify-content-center\">\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1810, "\"", 1846, 2);
            WriteAttributeValue("", 1817, "/receipts/details?id=", 1817, 21, true);
#line 35 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"
WriteAttributeValue("", 1838, item.Id, 1838, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1847, 104, true);
            WriteLiteral(" class=\"btn bg-panda text-white\">Details</a>\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 38 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Receipts\Index.cshtml"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Receipt[]> Html { get; private set; }
    }
}
#pragma warning restore 1591
