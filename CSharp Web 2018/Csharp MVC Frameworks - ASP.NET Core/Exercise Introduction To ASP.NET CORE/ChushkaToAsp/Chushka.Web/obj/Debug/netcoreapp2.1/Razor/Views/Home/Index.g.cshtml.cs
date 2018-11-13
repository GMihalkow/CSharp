#pragma checksum "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bef71a5028c85b27b0b4a83ab8ded7deb72505a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Home\Index.cshtml"
using Chushka.Web.ViewModels.Products;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bef71a5028c85b27b0b4a83ab8ded7deb72505a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28b1b7f90e180b0d87f381a53bb50c1d29a62730", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AllProductsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(70, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Home\Index.cshtml"
 if (!User.Identity.IsAuthenticated)
{

#line default
#line hidden
            BeginContext(113, 395, true);
            WriteLiteral(@"    <main>
        <div class=""jumbotron mt-3 chushka-bg-color"">
            <h1>Welcome to Chushka Universal Web Shop</h1>
            <hr class=""bg-white"" />
            <h3><a class=""nav-link-dark"" href=""/account/login"">Login</a> if you have an account.</h3>
            <h3><a class=""nav-link-dark"" href=""/account/register"">Register</a> if you don't.</h3>
        </div>
    </main>
");
            EndContext();
#line 14 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Home\Index.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(520, 81, true);
            WriteLiteral("    <main class=\"mt-3 mb-5\">\r\n        <div class=\"container-fluid text-center\">\r\n");
            EndContext();
#line 19 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Home\Index.cshtml"
             if (User.IsInRole("Admin"))
            {

#line default
#line hidden
            BeginContext(658, 93, true);
            WriteLiteral("                <h2>Greetings, admin!</h2>\r\n                <h4>Enjoy your work today!</h4>\r\n");
            EndContext();
#line 23 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Home\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(799, 31, true);
            WriteLiteral("                <h2>Greetings, ");
            EndContext();
            BeginContext(831, 18, false);
#line 26 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Home\Index.cshtml"
                          Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(849, 83, true);
            WriteLiteral("!</h2>\r\n                <h4>Feel free to view and order any of our products.</h4>\r\n");
            EndContext();
#line 28 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(947, 119, true);
            WriteLiteral("        </div>\r\n        <hr class=\"hr-2 bg-dark\" />\r\n        <div class=\"container-fluid product-holder\">\r\n            ");
            EndContext();
            BeginContext(1067, 47, false);
#line 32 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Home\Index.cshtml"
       Write(await Html.PartialAsync("_IndexPartial", Model));

#line default
#line hidden
            EndContext();
            BeginContext(1114, 32, true);
            WriteLiteral(";\r\n        </div>\r\n    </main>\r\n");
            EndContext();
#line 35 "C:\Users\Georgi-PC\Documents\Visual Studio 2017\Projects\ChushkaToAsp\Chushka.Web\Views\Home\Index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AllProductsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
