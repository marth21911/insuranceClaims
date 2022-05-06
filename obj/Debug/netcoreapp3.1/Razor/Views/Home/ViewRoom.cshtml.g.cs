#pragma checksum "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad93422e1f50a8f15546b42e1f5bddeec2ed4c80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewRoom), @"mvc.1.0.view", @"/Views/Home/ViewRoom.cshtml")]
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
#line 1 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\_ViewImports.cshtml"
using insuranceClaims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\_ViewImports.cshtml"
using insuranceClaims.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad93422e1f50a8f15546b42e1f5bddeec2ed4c80", @"/Views/Home/ViewRoom.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d2e867fd1098aaeab81ed07ce81dfdb8d2080c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewRoom : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OriginalInventory>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div>
    <table class=""table"">
        <thead class=""thead-dark"">
            <tr>
                <th scope=""col"">ID</th>
                <th scope=""col"">Product Lost</th>
                <th scope=""col"">Quantity Lost</th>
                <th scope=""col"">Unit Price</th>
                <th scope=""col"">Retail Quote</th>
                <th scope=""col"">Depreciation</th>
                <th scope=""col"">ACV Listed</th>
                <th scope=""col"">Actions</th> 
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 17 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml"
             foreach (OriginalInventory a in ViewBag.OneRoom)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 20 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml"
                           Write(a.UniqueID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml"
               Write(a.OldProduct);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml"
               Write(a.QuantityL);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>$");
#nullable restore
#line 23 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml"
                Write(a.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>$");
#nullable restore
#line 24 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml"
                Write(a.Retail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>$");
#nullable restore
#line 25 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml"
                Write(a.Depreciation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>$");
#nullable restore
#line 26 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml"
                Write(a.ACV);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><a href=\"/newReceipt\"/");
#nullable restore
#line 27 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml"
                                     Write(a.UniqueID);

#line default
#line hidden
#nullable disable
            WriteLiteral(" class=\"btn btn-info\">Add Receipt</a></td>\r\n            </tr>  \r\n");
#nullable restore
#line 29 "C:\Users\marth\Documents\coding\csharpDojo\insuranceClaims\Views\Home\ViewRoom.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OriginalInventory> Html { get; private set; }
    }
}
#pragma warning restore 1591
