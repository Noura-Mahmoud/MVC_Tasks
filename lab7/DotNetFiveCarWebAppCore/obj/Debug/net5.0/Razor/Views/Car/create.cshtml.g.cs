#pragma checksum "F:\ITI_mobile cross\MVC\Day7\lab7\DotNetFiveCarWebAppCore\Views\Car\create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53b920872b109c23a3b4c8e0732e03567cfbfe26"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Car_create), @"mvc.1.0.view", @"/Views/Car/create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53b920872b109c23a3b4c8e0732e03567cfbfe26", @"/Views/Car/create.cshtml")]
    #nullable restore
    public class Views_Car_create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "F:\ITI_mobile cross\MVC\Day7\lab7\DotNetFiveCarWebAppCore\Views\Car\create.cshtml"
  
    ViewBag.Title = "create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>create</h2>

<form method=""post"">
    <label>Num: </label>
    <input type=""text"" name=""num"" />
    <br />
    <label>Color: </label>
    <input type=""text"" name=""color"" />
    <br />
    <label>Model: </label>
    <input type=""text"" name=""model"" />
    <br />
    <label>Manfacture: </label>
    <input type=""text"" name=""manfacture"" />
    <br />
    <input type=""submit"" value=""Save"" />
</form>

");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591