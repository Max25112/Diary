#pragma checksum "D:\Project\VKR\Diary\Diary.Web\Views\Teacher\ViewHomework.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3065da53db489be0dcbcd09dedd9008af7612b4b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_ViewHomework), @"mvc.1.0.view", @"/Views/Teacher/ViewHomework.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3065da53db489be0dcbcd09dedd9008af7612b4b", @"/Views/Teacher/ViewHomework.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9660307487fd7a4fe6a1c8b5c2fa48736661bfb", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_ViewHomework : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Diary.Web.ViewModels.ViewHomework>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Project\VKR\Diary\Diary.Web\Views\Teacher\ViewHomework.cshtml"
  
    ViewData["Title"] = "ViewHomework";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-4"">
        <table class=""table table-striped"">
            <tr>
                <td>Название</td>
                <td>Класс</td>
                <td>Предмет</td>
                <td>Задание</td>
                <td>Время</td>
            </tr>
");
#nullable restore
#line 15 "D:\Project\VKR\Diary\Diary.Web\Views\Teacher\ViewHomework.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 18 "D:\Project\VKR\Diary\Diary.Web\Views\Teacher\ViewHomework.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 19 "D:\Project\VKR\Diary\Diary.Web\Views\Teacher\ViewHomework.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ClassName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 20 "D:\Project\VKR\Diary\Diary.Web\Views\Teacher\ViewHomework.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SubjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "D:\Project\VKR\Diary\Diary.Web\Views\Teacher\ViewHomework.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TaskText));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "D:\Project\VKR\Diary\Diary.Web\Views\Teacher\ViewHomework.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Deadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 24 "D:\Project\VKR\Diary\Diary.Web\Views\Teacher\ViewHomework.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Diary.Web.ViewModels.ViewHomework>> Html { get; private set; }
    }
}
#pragma warning restore 1591
