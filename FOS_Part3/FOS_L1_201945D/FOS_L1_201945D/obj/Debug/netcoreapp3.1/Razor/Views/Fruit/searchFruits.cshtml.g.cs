#pragma checksum "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a857541f86369305d3292eb33a6022e2b1ac5397"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fruit_searchFruits), @"mvc.1.0.view", @"/Views/Fruit/searchFruits.cshtml")]
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
#line 1 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\_ViewImports.cshtml"
using FOS_L1_201945D;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\_ViewImports.cshtml"
using FOS_L1_201945D.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\_ViewImports.cshtml"
using FOS_L1_201945D.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\_ViewImports.cshtml"
using FOS_L1_201945D.Models.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a857541f86369305d3292eb33a6022e2b1ac5397", @"/Views/Fruit/searchFruits.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d014c95ca4403b1a482b960077445a7564b51b5", @"/Views/_ViewImports.cshtml")]
    public class Views_Fruit_searchFruits : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FOS_L1_201945D.Models.ViewModels.searchFruitsByCat>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Fruit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "searchFruits", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h3>Search Fruit</h3>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a857541f86369305d3292eb33a6022e2b1ac53975022", async() => {
                WriteLiteral(@"
    <p>
        <label class=""label"">Category: </label>
        <input type=""text"" name=""category"" id=""category"" />

        <br />
        <br />

        <input type=""submit"" name=""search"" value=""Search Category"" />
        <input type=""reset"" name=""reset"" value=""Reset"" />
    </p>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<div class=""tg-wrap"">
    <table class=""tg"">
        <thead>
            <tr>
                <th class=""tg-0pky"">Id</th>
                <th class=""tg-0pky"">Name</th>
                <th class=""tg-0lax"">Category</th>
                <th class=""tg-0pky"">Country</th>
                <th class=""tg-0pky"">Price</th>
                <th class=""tg-0lax"">Unit Of Measurement</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 38 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml"
             foreach (var g in Model.CategoryList)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml"
                 foreach (var b in @g.Fruit)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td class=\"tg-0pky\">");
#nullable restore
#line 43 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml"
                                       Write(b.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"tg-0pky\">");
#nullable restore
#line 44 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml"
                                       Write(b.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"tg-0lax\">");
#nullable restore
#line 45 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml"
                                       Write(b.FruitCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"tg-0lax\">");
#nullable restore
#line 46 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml"
                                       Write(b.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"tg-0lax\">");
#nullable restore
#line 47 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml"
                                       Write(b.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"tg-0lax\">");
#nullable restore
#line 48 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml"
                                       Write(b.UnitOfMeasurement);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 50 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "H:\EGL219 Web Application Development\Project\FOS_Part3\FOS_L1_201945D\FOS_L1_201945D\Views\Fruit\searchFruits.cshtml"
                 

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FOS_L1_201945D.Models.ViewModels.searchFruitsByCat> Html { get; private set; }
    }
}
#pragma warning restore 1591
