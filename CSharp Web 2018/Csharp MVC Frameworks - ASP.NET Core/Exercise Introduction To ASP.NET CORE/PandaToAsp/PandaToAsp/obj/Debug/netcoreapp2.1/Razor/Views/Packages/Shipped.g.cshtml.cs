#pragma checksum "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Shipped.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8107df861e755a83ade4399c7d30422b52d0dd14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Packages_Shipped), @"mvc.1.0.view", @"/Views/Packages/Shipped.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Packages/Shipped.cshtml", typeof(AspNetCore.Views_Packages_Shipped))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8107df861e755a83ade4399c7d30422b52d0dd14", @"/Views/Packages/Shipped.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e93aacc8c8cb6571a779298540b9a9dd27ec8eaf", @"/Views/_ViewImports.cshtml")]
    public class Views_Packages_Shipped : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 990, true);
            WriteLiteral(@"<main class=""mt-3"">
    <h1 class=""text-center"">Shipped</h1>
    <hr class=""hr-2 bg-panda"">
    <div class=""d-flex justify-content-between"">
        <table class=""table table-hover table-bordered"">
            <thead>
                <tr class=""row"">
                    <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>#</h3></th>
                    <th scope=""col"" class=""col-lg-4 d-flex justify-content-center""><h3>Description</h3></th>
                    <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>Weight</h3></th>
                    <th scope=""col"" class=""col-lg-3 d-flex justify-content-center""><h3>Estimated Delivery Date</h3></th>
                    <th scope=""col"" class=""col-lg-2 d-flex justify-content-center""><h3>Recipient</h3></th>
                    <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>Actions</h3></th>
                </tr>
            </thead>
            <tbody>
               ");
            EndContext();
            BeginContext(991, 63, false);
#line 17 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\PandaToAsp\PandaToAsp\Views\Packages\Shipped.cshtml"
          Write(await Component.InvokeAsync("PackagesViewComponent", "Shipped"));

#line default
#line hidden
            EndContext();
            BeginContext(1054, 62, true);
            WriteLiteral(";\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</main>");
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
