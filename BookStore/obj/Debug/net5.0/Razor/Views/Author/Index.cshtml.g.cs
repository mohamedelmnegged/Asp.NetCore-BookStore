#pragma checksum "F:\Programming\applying\c#\Asp.Net Core\BookStore\BookStore\Views\Author\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0c9412a9303da46354d2600fb6e584e1c7f1a1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Author_Index), @"mvc.1.0.view", @"/Views/Author/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0c9412a9303da46354d2600fb6e584e1c7f1a1c", @"/Views/Author/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5488a0febac098cc5d1822b380d7630c7f2fb4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Author_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BookStore.Models.Author>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\Programming\applying\c#\Asp.Net Core\BookStore\BookStore\Views\Author\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n");
#nullable restore
#line 9 "F:\Programming\applying\c#\Asp.Net Core\BookStore\BookStore\Views\Author\Index.cshtml"
Write(Html.Partial("_Author", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n\r\n");
            DefineSection("Search", async() => {
                WriteLiteral("\r\n    <input class=\"form-control me-2\" type=\"search\" name=\"value\" id=\"LiveSearch\"");
                BeginWriteAttribute("onkeyup", "\r\n           onkeyup=\"", 241, "\"", 339, 3);
                WriteAttributeValue("", 263, "searchResult(\'", 263, 14, true);
#nullable restore
#line 13 "F:\Programming\applying\c#\Asp.Net Core\BookStore\BookStore\Views\Author\Index.cshtml"
WriteAttributeValue("", 277, Url.Action("Search","Author", null, Context.Request.Scheme), 277, 60, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 337, "\')", 337, 2, true);
                EndWriteAttribute();
                WriteLiteral("\r\n           placeholder=\"Search For Author\" aria-label=\"Search\" style=\"float:right\">\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BookStore.Models.Author>> Html { get; private set; }
    }
}
#pragma warning restore 1591
