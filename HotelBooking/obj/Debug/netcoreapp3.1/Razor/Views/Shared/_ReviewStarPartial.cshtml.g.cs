#pragma checksum "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b6050029a58227137fdaec36d283bf9d1dc0715"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ReviewStarPartial), @"mvc.1.0.view", @"/Views/Shared/_ReviewStarPartial.cshtml")]
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
#line 1 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\_ViewImports.cshtml"
using HotelBooking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\_ViewImports.cshtml"
using HotelBooking.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\_ViewImports.cshtml"
using Entities.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\_ViewImports.cshtml"
using HotelBooking.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b6050029a58227137fdaec36d283bf9d1dc0715", @"/Views/Shared/_ReviewStarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"356ccd48717a9e3b29da33e625fef5719d04e073", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__ReviewStarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoomVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" shadow-1-strong me-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/emojis/user (2).png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("avatar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("60"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("60"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
  
    double avgstar = Model.Room.Comments.Count() > 0 ? (Model.Room.Comments.Sum(s => s.Star) / (double)Model.Room.Comments.Count()) : 0;
    int commentcount = Model.Room.Comments.Count() > 0 ? Model.Room.Comments.Count() : 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .reviewtext {
        position: relative;
    }

    .icons {
        margin-bottom: 20px;
    }
</style>
<section>
    <div class=""container py-5"">
        <div class=""row d-flex justify-content-center"">
                <div class=""d-flex align-items-center justify-content-between mb-3"">
                    <h2 style=""color:#32445D;font-weight:bold"">");
#nullable restore
#line 20 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                                                           Write(commentcount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Comments</h2>\r\n                    <strong>Rating scale -<span style=\"color:blue\"> ");
#nullable restore
#line 21 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                                                                Write((avgstar).ToString("0.0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></strong>\r\n                </div>\r\n            <div>\r\n");
#nullable restore
#line 24 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                 foreach (Comment review in Model.Comments)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                     if (Model.Room.Id == review.RoomId)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"card mb-3\">\r\n                            <div class=\"card-body\">\r\n                                <div class=\"d-flex flex-start align-items-center\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9b6050029a58227137fdaec36d283bf9d1dc07157674", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <div>\r\n                                        <h6 class=\"fw-bold text-primary mb-1\">");
#nullable restore
#line 33 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                                                                         Write(review.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                        <p class=\"text-muted small mb-0\" style=\"color:#32445D;font-weight:600\">\r\n                                            Shared publicly - ");
#nullable restore
#line 35 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                                                         Write(review.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </p>\r\n                                    </div>\r\n                                </div>\r\n                                <p class=\"mt-3 mb-4 pb-2\">\r\n                                    ");
#nullable restore
#line 40 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                               Write(review.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n                                <div class=\"small d-flex justify-content-between\">\r\n                                    <div class=\"icons\" style=\"color:#FFC107;\">\r\n");
#nullable restore
#line 44 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                                         for (int i = 0; i < review.Star; i++)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <i class=\"fa-solid fa-star\"></i>\r\n");
#nullable restore
#line 47 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 52 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Shared\_ReviewStarPartial.cshtml"
                     

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</section>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.LayoutService layoutService { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoomVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
