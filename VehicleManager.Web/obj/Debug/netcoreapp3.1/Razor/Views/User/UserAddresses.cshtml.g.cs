#pragma checksum "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e05eef92207bdad2d1be458c92a7185653dff82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UserAddresses), @"mvc.1.0.view", @"/Views/User/UserAddresses.cshtml")]
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
#nullable restore
#line 1 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\_ViewImports.cshtml"
using VehicleManager.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\_ViewImports.cshtml"
using VehicleManager.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e05eef92207bdad2d1be458c92a7185653dff82", @"/Views/User/UserAddresses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ddfbdedec2e2b1694f80e457054e8931b9d1b1", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UserAddresses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VehicleManager.Application.ViewModels.UserModels.UserAdressesForListVm>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddAddress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Address", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
  
    ViewData["Title"] = "UserAddresses";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<h1>UserAddresses</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e05eef92207bdad2d1be458c92a7185653dff824327", async() => {
                WriteLiteral("Dodaj nowy adres");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n");
#nullable restore
#line 15 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
  
    var tmpData = TempData["succesMessage"];

    if (tmpData != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-primary\" role=\"alert\">\r\n            ");
#nullable restore
#line 21 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
       Write(tmpData);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 23 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table class=""table"">
    <thead>
        <tr>
            <th>
                Numer adresu
            </th>
            <th>
                Szczegóły
            </th>
            <th>
                Rodzaj adresu
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 41 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
          
            int i = 0;

            foreach (var item in Model)
            {
                i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 49 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 52 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
                   Write(item.Voivedoshipha);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p></p>\r\n                        ");
#nullable restore
#line 53 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
                   Write(item.Districts);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p></p>\r\n                        ");
#nullable restore
#line 54 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
                   Write(item.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p></p>\r\n                        ");
#nullable restore
#line 55 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
                   Write(item.CityAndType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p></p>\r\n                        ");
#nullable restore
#line 56 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
                   Write(item.StreetAndBuildNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p></p>\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
                   Write(Html.DisplayFor(modelItem => item.KindOfAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
                   Write(Html.ActionLink("Edit", "EditAddress", "Address", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 63 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
                   Write(Html.ActionLink("Usuń", "Delete", "Address", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 66 "C:\Users\wagne\Desktop\Kurs programista asp.net core\Nowy folder\VehicleManager\VehicleManager.Web\Views\User\UserAddresses.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VehicleManager.Application.ViewModels.UserModels.UserAdressesForListVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591
