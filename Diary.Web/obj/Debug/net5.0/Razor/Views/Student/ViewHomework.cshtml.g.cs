#pragma checksum "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48e75fb0d82b34cb3fc1c384910fa381f24082f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_ViewHomework), @"mvc.1.0.view", @"/Views/Student/ViewHomework.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48e75fb0d82b34cb3fc1c384910fa381f24082f8", @"/Views/Student/ViewHomework.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9660307487fd7a4fe6a1c8b5c2fa48736661bfb", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_ViewHomework : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Diary.Web.ViewModels.ViewHomework>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Student", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DownloadFile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
  
    ViewData["Title"] = "ViewHomework";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-4"">
        <table class=""table table-striped"">
            <tr>
                <td>????????????????</td>
                <td>????????????????</td>
                <td>??????????????</td>
                <td>??????????????</td>
                <td>??????????????</td>
                <td>??????????</td>
                <td>??????????</td>
            </tr>
");
#nullable restore
#line 17 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n");
#nullable restore
#line 21 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                         if (item.IsExists)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                       Write(Html.ActionLink("????????????????", "UpdateResponse", new { HomeworkResultId = item.HomeworkResultId }, null));

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                                                                                                                                  
                        }
                        else
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                       Write(Html.ActionLink("????????????????", "Response", new { HomeworkId = item.Id }, null));

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                                                                                                        
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>");
#nullable restore
#line 30 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                   Write(Html.DisplayFor(modelItem => item.FIO));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SubjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TaskText));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 34 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Deadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n");
#nullable restore
#line 36 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                         foreach (var doc in item.Attachments)
                        {
                            var Name = doc.Name + doc.Extension;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48e75fb0d82b34cb3fc1c384910fa381f24082f88537", async() => {
#nullable restore
#line 39 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                                                                                                                                                       Write(doc.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                                                                                                                                                                Write(doc.Extension);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 39 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
AddHtmlAttributeValue("", 1691, doc.Id, 1691, 7, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                                                                                                                                       WriteLiteral(doc.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 40 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 43 "D:\Project\VKR\Diary\Diary.Web\Views\Student\ViewHomework.cshtml"
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
