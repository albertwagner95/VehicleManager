#pragma checksum "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c37ceb82c5e49b38dedf0e237a4b6be211e34bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehicle_VehicleDetails), @"mvc.1.0.view", @"/Views/Vehicle/VehicleDetails.cshtml")]
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
#line 1 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\_ViewImports.cshtml"
using VehicleManager.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\_ViewImports.cshtml"
using VehicleManager.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c37ceb82c5e49b38dedf0e237a4b6be211e34bb", @"/Views/Vehicle/VehicleDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ddfbdedec2e2b1694f80e457054e8931b9d1b1", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehicle_VehicleDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VehicleManager.Application.ViewModels.Vehicle.VehicleDetailsVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
  
    ViewData["Title"] = "VehicleDetails";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>VehicleDetails</h1>\r\n");
#nullable restore
#line 8 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
Write(ViewBag.NullVehicles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h4>VehicleDetailsVm</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Vin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.Vin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Millage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.Millage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.DateOfFirstRegistration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.DateOfFirstRegistration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.IsRegisterdInPoland));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.IsRegisterdInPoland));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.RegistrationNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.RegistrationNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.ProductionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.EnginePower));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 65 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.EnginePower));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 68 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.EngineCapacity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 71 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.EngineCapacity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 74 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.PermissibleGrossWeight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 77 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.PermissibleGrossWeight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 80 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Capacity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 83 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.Capacity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 86 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.OwnWeight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 89 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.OwnWeight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 92 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.YearHelper));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 95 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.YearHelper));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 98 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.ApplicationUserID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 101 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.ApplicationUserID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 104 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.VehicleFuelTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 107 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.VehicleFuelTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 110 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.VehicleBrandNameId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 113 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.VehicleBrandNameId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 116 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.VehicleTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 119 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
       Write(Html.DisplayFor(model => model.VehicleTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 124 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\VehicleDetails.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c37ceb82c5e49b38dedf0e237a4b6be211e34bb18544", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VehicleManager.Application.ViewModels.Vehicle.VehicleDetailsVm> Html { get; private set; }
    }
}
#pragma warning restore 1591