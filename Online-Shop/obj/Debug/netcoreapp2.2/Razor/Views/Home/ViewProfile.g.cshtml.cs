#pragma checksum "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d38f2d4666ac34db302e7d92ea7014fc98a67e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Online_Shop.Views.Home.Views_Home_ViewProfile), @"mvc.1.0.view", @"/Views/Home/ViewProfile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ViewProfile.cshtml", typeof(Online_Shop.Views.Home.Views_Home_ViewProfile))]
namespace Online_Shop.Views.Home
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d38f2d4666ac34db302e7d92ea7014fc98a67e2", @"/Views/Home/ViewProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a5489a05befeeae653e7dba7cfd252ff343c974", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Online_Shop.ViewModels.ViewModelFood>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(101, 140, true);
            WriteLiteral("\r\n<h1>View profile</h1>\r\n<hr class=\"accent my-5\">\r\n\r\n<table class=\"table table-striped\">\r\n    <tr>\r\n        <td>Username </td>\r\n        <td>");
            EndContext();
            BeginContext(242, 30, false);
#line 13 "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml"
       Write(Model.CurrentCustomer.Username);

#line default
#line hidden
            EndContext();
            BeginContext(272, 18, true);
            WriteLiteral("</td>\r\n    </tr>\r\n");
            EndContext();
#line 15 "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml"
     if (User.IsInRole("Premium"))
    {

#line default
#line hidden
            BeginContext(331, 64, true);
            WriteLiteral("        <tr>\r\n            <td>Premium</td>\r\n            <td><h6>");
            EndContext();
            BeginContext(396, 28, false);
#line 19 "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml"
               Write(Model.CurrentCustomer.Points);

#line default
#line hidden
            EndContext();
            BeginContext(424, 34, true);
            WriteLiteral(" points</h6></td>\r\n        </tr>\r\n");
            EndContext();
#line 21 "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml"
    }

#line default
#line hidden
            BeginContext(465, 47, true);
            WriteLiteral("    <tr>\r\n        <td>Email </td>\r\n        <td>");
            EndContext();
            BeginContext(513, 27, false);
#line 24 "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml"
       Write(Model.CurrentCustomer.Email);

#line default
#line hidden
            EndContext();
            BeginContext(540, 65, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Phone </td>\r\n        <td>");
            EndContext();
            BeginContext(606, 27, false);
#line 28 "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml"
       Write(Model.CurrentCustomer.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(633, 67, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Address </td>\r\n        <td>");
            EndContext();
            BeginContext(701, 29, false);
#line 32 "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml"
       Write(Model.CurrentCustomer.Address);

#line default
#line hidden
            EndContext();
            BeginContext(730, 64, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>City </td>\r\n        <td>");
            EndContext();
            BeginContext(795, 26, false);
#line 36 "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml"
       Write(Model.CurrentCustomer.City);

#line default
#line hidden
            EndContext();
            BeginContext(821, 71, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Postal code </td>\r\n        <td>");
            EndContext();
            BeginContext(893, 32, false);
#line 40 "/Users/alicina/Projects/Online-Shop/Online-Shop/Views/Home/ViewProfile.cshtml"
       Write(Model.CurrentCustomer.PostalCode);

#line default
#line hidden
            EndContext();
            BeginContext(925, 30, true);
            WriteLiteral("</td>\r\n    </tr>\r\n</table>\r\n\r\n");
            EndContext();
            BeginContext(955, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d38f2d4666ac34db302e7d92ea7014fc98a67e27549", async() => {
                BeginContext(1005, 46, true);
                WriteLiteral("<i class=\"fas fa-pencil-alt\"></i> Edit profile");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1055, 10, true);
            WriteLiteral("\r\n<br />\r\n");
            EndContext();
            BeginContext(1065, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d38f2d4666ac34db302e7d92ea7014fc98a67e29157", async() => {
                BeginContext(1109, 47, true);
                WriteLiteral("<i class=\"fas fa-chevron-circle-left\"></i> Menu");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Online_Shop.ViewModels.ViewModelFood> Html { get; private set; }
    }
}
#pragma warning restore 1591
