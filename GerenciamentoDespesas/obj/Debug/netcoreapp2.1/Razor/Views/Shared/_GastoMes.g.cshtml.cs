#pragma checksum "C:\Users\Giovanne\source\repos\GerenciamentoDespesas\GerenciamentoDespesas\Views\Shared\_GastoMes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89a81e782e4a536328683ee881862bb77213ee58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GastoMes), @"mvc.1.0.view", @"/Views/Shared/_GastoMes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_GastoMes.cshtml", typeof(AspNetCore.Views_Shared__GastoMes))]
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
#line 1 "C:\Users\Giovanne\source\repos\GerenciamentoDespesas\GerenciamentoDespesas\Views\_ViewImports.cshtml"
using GerenciamentoDespesas;

#line default
#line hidden
#line 2 "C:\Users\Giovanne\source\repos\GerenciamentoDespesas\GerenciamentoDespesas\Views\_ViewImports.cshtml"
using GerenciamentoDespesas.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89a81e782e4a536328683ee881862bb77213ee58", @"/Views/Shared/_GastoMes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29d78ec6cf95a9eef2e83ea865fe67616125d9e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__GastoMes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 119, true);
            WriteLiteral("<div class=\"graficoGastosMes\">\r\n    <canvas id=\"graficoGastosMes\" style=\"width:300px; height:300px\"></canvas>\r\n</div>\r\n");
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
