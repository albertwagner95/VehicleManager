#pragma checksum "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3305b88b175671850658dab6ff4f8c9e31f4a6a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehicle_RefuelingDetails), @"mvc.1.0.view", @"/Views/Vehicle/RefuelingDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3305b88b175671850658dab6ff4f8c9e31f4a6a9", @"/Views/Vehicle/RefuelingDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ddfbdedec2e2b1694f80e457054e8931b9d1b1", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehicle_RefuelingDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VehicleManager.Application.ViewModels.Vehicle.RefuelDetailsVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CarHistory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Vehicle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
  
    ViewData["Title"] = "RefuelingDetails";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>RefuelingDetails</h1>\r\n\r\n<div>\r\n    <h4>RefuelDetailsVm</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            Ilość paliwa\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.AmountOfFuel));

#line default
#line hidden
#nullable disable
            WriteLiteral(" j.(");
#nullable restore
#line 18 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
                                                        Write(Model.UnitOfFuelName);

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Kwota tankowania\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.FuelPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Cena za jednostkę paliwa\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.PriceForOneUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral(" zł\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Przebieg\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.MeterStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral(" km\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Nazwa stacji\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.PetrolStationName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Tankowanie do pełna\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.IsRefulingFull));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Uwagi\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.Varnings));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Pojazd\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.VehicleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Spalanie na 100 km\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.BurningFuelPerOneHundredKilometers));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd> \r\n        <dt class=\"col-sm-2\">\r\n            Jednostka paliwa\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.UnitOfFuelName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Rodzaj paliwa\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 78 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.FuelName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Data tankowania\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 84 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
       Write(Html.DisplayFor(model => model.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 89 "C:\Users\wagne\Desktop\Kurs programista asp.net core\VehicleManager\VehicleManager\VehicleManager.Web\Views\Vehicle\RefuelingDetails.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3305b88b175671850658dab6ff4f8c9e31f4a6a910730", async() => {
                WriteLiteral("Wróć do historii zdarzeń");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VehicleManager.Application.ViewModels.Vehicle.RefuelDetailsVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
