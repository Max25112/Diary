#pragma checksum "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewLesson.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7aea73d8e3864132bfbc80f91a46b8dab8aba0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_ViewLesson), @"mvc.1.0.view", @"/Views/Student/ViewLesson.cshtml")]
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
#line 1 "D:\Project\VKR\Diary\Diary.Web\Views\_ViewImports.cshtml"
using Diary.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\VKR\Diary\Diary.Web\Views\_ViewImports.cshtml"
using Diary.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7aea73d8e3864132bfbc80f91a46b8dab8aba0f", @"/Views/Student/ViewLesson.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9660307487fd7a4fe6a1c8b5c2fa48736661bfb", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_ViewLesson : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string[,]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewLesson.cshtml"
  
    ViewData["Title"] = "Lessons";
    int n = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-4"">
        <table class=""table table-striped"">
            <thead>
                <tr>
                    <td>№</td>
                    <td>Понедельник</td>
                    <td>Вторник</td>
                    <td>Среда</td>
                    <td>Четверг</td>
                    <td>Пятница</td>
                    <td>Суббота</td>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 21 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewLesson.cshtml"
                 for (int j = 0; j <= 6; j++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td><p>");
#nullable restore
#line 24 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewLesson.cshtml"
                          Write(n);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n");
#nullable restore
#line 25 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewLesson.cshtml"
                         for (int i = 0; i <= 5; i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><p>");
#nullable restore
#line 27 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewLesson.cshtml"
                              Write(Model[i, j]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n");
#nullable restore
#line 28 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewLesson.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewLesson.cshtml"
                          n++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n");
#nullable restore
#line 31 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewLesson.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string[,]> Html { get; private set; }
    }
}
#pragma warning restore 1591
