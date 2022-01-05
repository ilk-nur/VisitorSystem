#pragma checksum "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f80d942c774bd2d89246ae580b2d41204628d4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Visitor_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Visitor/Index.cshtml")]
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
#line 1 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
using VisitorSystem.Shared.Utilities.Results.ComplexTypes;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f80d942c774bd2d89246ae580b2d41204628d4e", @"/Areas/Admin/Views/Visitor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Visitor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VisitorSystem.Entities.Dtos.VisitorDto.VisitorListDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("alert-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/visitorIndex.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
  
    Layout = "_Layout";
    ViewBag.Title = "Ziyaretçiler Index";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
 if (Model.ResultStatus == ResultStatus.Success)
{



#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"modalPlaceHolder\" aria-hidden=\"true\"></div>\r\n");
            WriteLiteral(@"    <div class=""card mb-4 m-2"">
        <div class=""card-header"">
            <i class=""fas fa-table mr-1""></i>
            Ziyaretçiler
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""visitorsTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>Tc No</th>
                            <th>Adı</th>
                            <th>Soyadı</th>
                            <th>Doğum Tarihi</th>
                            <th>İletişim No</th>
                            <th>Giriş Tarihi-Saati</th>
                            <th>Çıkış Tarihi-Saati</th>
                            <th>Geldiği Birim</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>Tc No</th>
                    ");
            WriteLiteral(@"        <th>Adı</th>
                            <th>Soyadı</th>
                            <th>Doğum Tarihi</th>
                            <th>İletişim No</th>
                            <th>Giriş Tarihi-Saati</th>
                            <th>Çıkış Tarihi-Saati</th>
                            <th>Geldiği Birim</th>
                            <th>İşlemler</th>

                        </tr>
                    </tfoot>
                    <tbody>
");
#nullable restore
#line 49 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                         foreach (var visitor in Model.Visitors)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("name", " name=\"", 1931, "\"", 1949, 1);
#nullable restore
#line 51 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
WriteAttributeValue("", 1938, visitor.Id, 1938, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td>");
#nullable restore
#line 52 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                           Write(visitor.TcNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 53 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                           Write(visitor.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 54 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                           Write(visitor.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 55 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                           Write(visitor.BirthDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 56 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                           Write(visitor.ContactNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 57 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                           Write(visitor.EnterDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 57 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                                                                  Write(visitor.EnterDate.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 58 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                             if (visitor.IsExit == false)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td ><div class=\"badge bg-success text-wrap\">Çıkış Yapılmadı</div></td>\r\n");
#nullable restore
#line 61 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>");
#nullable restore
#line 65 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                               Write(visitor.OutDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 65 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                                                                    Write(visitor.OutDate.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 66 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <td>");
#nullable restore
#line 69 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                           Write(visitor.Department.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <button class=\"btn btn-primary btn-sm btn-block btn-exit\" data-id=\"");
#nullable restore
#line 71 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                                                                                              Write(visitor.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" style=\"background-color:blue; border-color:blue \"><span class=\"fas fa-sign-in-alt\"></span></button>\r\n\r\n                                <button class=\"btn btn-danger  btn-sm btn-block btn-delete\" data-id=\"");
#nullable restore
#line 73 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
                                                                                                Write(visitor.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><span class=\"fas fa-minus-circle\"></span></button>\r\n                            </td>\r\n\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 78 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"



                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 89 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
 if (Model.ResultStatus == ResultStatus.Error)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger m-2\">\r\n        ");
#nullable restore
#line 93 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"
   Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n        Dashboard sayfasına dönmek için lütfen ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f80d942c774bd2d89246ae580b2d41204628d4e14398", async() => {
                WriteLiteral(" tıklayınız.");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    </div>\r\n");
#nullable restore
#line 97 "C:\Users\pc\source\repos\VisitorSystem\VisitorSystem.Mvc\Areas\Admin\Views\Visitor\Index.cshtml"

}

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f80d942c774bd2d89246ae580b2d41204628d4e16347", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VisitorSystem.Entities.Dtos.VisitorDto.VisitorListDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
