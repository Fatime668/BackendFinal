#pragma checksum "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abd243aeb682fa674a423766a671d353b3464755"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abd243aeb682fa674a423766a671d353b3464755", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"356ccd48717a9e3b29da33e625fef5719d04e073", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Hotel Booking ";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
 if (TempData["ForgotPassword"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"hidden\" id=\"forgotJs\" />\r\n");
#nullable restore
#line 8 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
 if (TempData["PasswordResed"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"hidden\" id=\"resedJs\" />\r\n");
#nullable restore
#line 12 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
 if (TempData["Verify"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"hidden\" id=\"verifyJs\" />\r\n");
#nullable restore
#line 16 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
 if (TempData["Verified"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"hidden\" id=\"verifiedJs\" />\r\n");
#nullable restore
#line 20 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
 if (TempData["Booking"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"hidden\" id=\"bookingJs\" />\r\n");
#nullable restore
#line 24 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
 if (TempData["EditPassword"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"hidden\" id=\"editJs\" />\r\n");
#nullable restore
#line 28 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<main>
    <!-- intro start -->
    <section id=""intro"">
        <div class=""bg-color""></div>
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-8"">
                    <div class=""title"">
                        <span class=""subtitle"" data-aos=""fade-up"" data-aos-duration=""500"" data-aos-delay=""500""
                              data-aos-anchor-placement=""center-bottom"">");
#nullable restore
#line 38 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                                                                   Write(layoutService.GetSetting().Result.FirstOrDefault(s => s.Key.Trim().ToLower() == "headersubtitle").Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <h1 style=\"width:80%\" data-aos=\"fade-up\" data-aos-duration=\"1500\" data-aos-delay=\"500\"\r\n                            data-aos-anchor-placement=\"center-bottom\">\r\n                            ");
#nullable restore
#line 41 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                       Write(layoutService.GetSetting().Result.FirstOrDefault(s => s.Key.Trim().ToLower() == "headertitle").Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                        </h1>
                        <span class=""adventure"" data-aos=""fade-up"" data-aos-duration=""500"" data-aos-delay=""500""
                              data-aos-anchor-placement=""center-bottom"">Adventure</span>
                    </div>
                </div>
            </div>
        </div>
        <a href=""#about"" class=""scroll-to"">
            Scroll
            <span class=""scroll-line""></span>
        </a>
    </section>
    <!-- intro end -->
    <!-- about start -->
    <section id=""about"">
        <div class=""container"">
            <div class=""heading"">
                <span >About us</span>
                <h1 class=""title"" >
                    Begin your amazing <br> adventure.
                </h1>
            </div>
            <div class=""row justify-content-center"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6"">
                    <div class=""text-left"">
                        <p>
                            The humid sub");
            WriteLiteral(@"tropical climate, high mountains,
                            exotic vegetation, endless beaches,
                            national parks, historic architecture, exciting attraction sites, art festivals and
                            lively multicultural environment make Sochi a prominent resort destination.
                        </p>
                    </div>
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6"">
                    <div class=""text-right"">
                        <p>
                            Sochi has a lot to offer for anyone who loves
                            nature, sports, history, sunny beach
                            leisure and active adventures. There is too much to do and too many things to see in
                            Sochi so you will never be bored.
                        </p>
                    </div>
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6"">

             ");
            WriteLiteral(@"       <div class=""left-img"">
                        <a href=""#"" class=""about-link"">
                            Explore More
                            <i class=""fa-solid fa-arrow-right-long""></i>
                        </a>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abd243aeb682fa674a423766a671d353b346475510477", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3756, "~/assets/images/about/", 3756, 22, true);
#nullable restore
#line 93 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 3778, layoutService.GetSetting().Result.FirstOrDefault(s=>s.Key.Trim().ToLower()=="aboutleftimage").Value, 3778, 100, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12 col-sm-12 col-md-12 col-lg-6\">\r\n                    <div class=\"right-img\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abd243aeb682fa674a423766a671d353b346475512342", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4087, "~/assets/images/about/", 4087, 22, true);
#nullable restore
#line 98 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 4109, layoutService.GetSetting().Result.FirstOrDefault(s=>s.Key.Trim().ToLower()=="aboutrightimage").Value, 4109, 101, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- about end -->
    <!-- room start -->
    <section id=""room"">
        <div class=""container"">
            <div class=""row align-items-center"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6"">
                    <div class=""heading"">
                        <span class=""room"" data-aos=""fade-up"" data-aos-duration=""1000"" data-aos-delay=""500""
                              data-aos-anchor-placement=""center-bottom"">Rooms</span>
                        <h1 class=""title"">
                            <span data-aos=""fade-up"" data-aos-duration=""1000"" data-aos-delay=""500""
                                  data-aos-anchor-placement=""center-bottom"">Rooms</span>
                            <span data-aos=""fade-up"" data-aos-duration=""1000"" data-aos-delay=""500""
                                  data-aos-anchor-placement=""center-bottom""> Suites.</span>
                        </h1>");
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-6 see-more d-flex justify-content-end"">
                    <div class=""btn-more"">
                        <a href=""/room/index"">See all Rooms</a>
                    </div>
                </div>
            </div>
            <div class=""row"">
");
#nullable restore
#line 128 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                 foreach (var item in Model.Rooms)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 130 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                     if (item.IsFeatured == true)
                    {
                        if (item.IsPopular == true)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""col-lg-8 m-0 p-0"">
                                <div class=""roomItem"">
                                    <span class=""popular"">Popular</span>
                                    <div class=""img"">
                                        <a");
            BeginWriteAttribute("href", " href=\"", 6124, "\"", 6153, 2);
            WriteAttributeValue("", 6131, "/room/details/", 6131, 14, true);
#nullable restore
#line 138 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
WriteAttributeValue("", 6145, item.Id, 6145, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("roomId", "  roomId=\"", 6154, "\"", 6172, 1);
#nullable restore
#line 138 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
WriteAttributeValue("", 6164, item.Id, 6164, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"itemRoom_link\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abd243aeb682fa674a423766a671d353b346475517205", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6252, "~/assets/images/rooms/", 6252, 22, true);
#nullable restore
#line 139 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 6274, item.RoomPictures.FirstOrDefault(r=>r.IsMain==true)?.ImagePath, 6274, 63, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </a>\r\n                                    </div>\r\n                                    <div class=\"room-detail\">\r\n                                        <h4>");
#nullable restore
#line 143 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                        <div class=\"price\">\r\n                                            $");
#nullable restore
#line 145 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                                        Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            <span>night</span>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 151 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-12 col-sm-12 col-md-12 col-lg-4 m-0 p-0\">\r\n                                <div class=\"roomItem\">\r\n                                    <div class=\"img\">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 7238, "\"", 7267, 2);
            WriteAttributeValue("", 7245, "/room/details/", 7245, 14, true);
#nullable restore
#line 157 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
WriteAttributeValue("", 7259, item.Id, 7259, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"itemRoom_link\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abd243aeb682fa674a423766a671d353b346475520935", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 7347, "~/assets/images/rooms/", 7347, 22, true);
#nullable restore
#line 158 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 7369, item.RoomPictures.FirstOrDefault(r=>r.IsMain==true)?.ImagePath, 7369, 63, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </a>\r\n                                    </div>\r\n\r\n                                    <div class=\"room-detail\">\r\n                                        <h4>");
#nullable restore
#line 163 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                        <div class=\"price\">\r\n                                            $");
#nullable restore
#line 165 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                                        Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            <span>night</span>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 171 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                        }

                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 173 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

            </div>
        </div>
    </section>
    <!-- room end -->
    <!-- counter start -->
    <section id=""counter"">
        <div class=""container"">
            <div class=""title"">
                <p data-aos=""fade-up"" data-aos-duration=""1000"" data-aos-delay=""500""
                   data-aos-anchor-placement=""center-bottom"">
                    We strive to be the best in our field to make you <br>
                    even more comfortable.
                </p>
            </div>
            <div class=""row"">
                <div class=""col-12 col-sm-6 col-md-6 col-lg-3"">
                    <div class=""item-box"">
                        <div class=""item-title"">
                            <span>SPA OFFERS</span>
                        </div>
                        <div class=""item-count"">
                            <span class=""counter"">32</span>+
                        </div>
                    </div>
                </div>
                <div class=""col-12 col-sm-");
            WriteLiteral(@"6 col-md-6 col-lg-3"">
                    <div class=""item-box"">
                        <div class=""item-title"">
                            <span>ROOMS</span>
                        </div>
                        <div class=""item-count"">
                            <span class=""counter"">");
#nullable restore
#line 208 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                                             Write(Model.Rooms.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>+
                        </div>
                    </div>
                </div>
                <div class=""col-12 col-sm-6 col-md-6 col-lg-3"">
                    <div class=""item-box"">
                        <div class=""item-title"">
                            <span>BEACHES</span>
                        </div>
                        <div class=""item-count"">
                            <span class=""counter"">");
#nullable restore
#line 218 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                                             Write(Model.Galleries.Where(g=>g.CategoryId==3).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>+
                        </div>
                    </div>
                </div>
                <div class=""col-12 col-sm-6 col-md-6 col-lg-3"">
                    <div class=""item-box"">
                        <div class=""item-title"">
                            <span>HAPPY CLIENTS</span>
                        </div>
                        <div class=""item-count"">
                            <span class=""counter"">10</span>k
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section> <!-- counter end -->
    <!-- testimonial start -->
    <section id=""testimonial"">
        <div class=""container"">
            <div class=""title"">
                <span data-aos=""fade-up"" data-aos-duration=""1000"" data-aos-delay=""500""
                      data-aos-anchor-placement=""center-bottom"">TESTIMONIALS</span>
                <h1 data-aos=""fade-up"" data-aos-duration=""1000"" data-aos-delay=""500""
                    data-");
            WriteLiteral("aos-anchor-placement=\"center-bottom\">\r\n                    What clients say about us.\r\n                </h1>\r\n            </div>\r\n            <div class=\"testimonial-carousel owl-carousel owl-theme\">\r\n");
#nullable restore
#line 247 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                 foreach (var item in Model.Testimonials)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"item\">\r\n                        <div class=\"txt\">\r\n                            <h4>Best hotel!</h4>\r\n                            <p>\r\n                                ");
#nullable restore
#line 253 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                           Write(item.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n\r\n                        </div>\r\n                        <div class=\"author d-flex align-items-center\">\r\n                            <div class=\"author-photo\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abd243aeb682fa674a423766a671d353b346475528737", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 11662, "~/assets/images/testimonial/", 11662, 28, true);
#nullable restore
#line 259 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 11690, item.Image, 11690, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                            <div>\r\n                                <div class=\"name\">");
#nullable restore
#line 262 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"
                                             Write(item.Client);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                <div class=\"country\">from France</div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 267 "C:\Users\user\source\repos\HotelBooking\HotelBooking\Views\Home\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
    </section>
    <!-- testimonial end -->
    <!-- make room start -->
    <section id=""make"">
        <div class=""container"">
            <div class=""row  align-items-center"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-7"">
                    <div class=""title"">
                        <h2>Make room for adventure.</h2>
                        <p>
                            Book your room right now and start your amazing adventure full of discoveries and
                            experiences with Sochi.
                        </p>
                    </div>
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-5 d-flex justify-content-end"">
                    <div class=""btn-rezerv"">
                        <a href=""/room/index"">
                            Reservations
                            <i class=""fa-solid fa-right-long""></i>
                        </a>
                    </div>
     ");
            WriteLiteral("           </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n    <!-- make room end -->\r\n</main>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function() {
            if ($(""#forgotJs"").length) {
                Command: toastr[""success""](""Please check your gmail"")

                toastr.options = {
                    ""closeButton"": false,
                    ""debug"": false,
                    ""newestOnTop"": false,
                    ""progressBar"": false,
                    ""positionClass"": ""toast-top-right"",
                    ""preventDuplicates"": false,
                    ""onclick"": null,
                    ""showDuration"": ""300"",
                    ""hideDuration"": ""1000"",
                    ""timeOut"": ""7000"",
                    ""extendedTimeOut"": ""2000"",
                    ""showEasing"": ""swing"",
                    ""hideEasing"": ""linear"",
                    ""showMethod"": ""fadeIn"",
                    ""hideMethod"": ""fadeOut""
                }
            }
            if ($(""#resedJs"").length) {
                Command: toastr[""success""](""Your password has been successfu");
                WriteLiteral(@"lly changed"")

                toastr.options = {
                    ""closeButton"": false,
                    ""debug"": false,
                    ""newestOnTop"": false,
                    ""progressBar"": false,
                    ""positionClass"": ""toast-top-right"",
                    ""preventDuplicates"": false,
                    ""onclick"": null,
                    ""showDuration"": ""300"",
                    ""hideDuration"": ""1000"",
                    ""timeOut"": ""7000"",
                    ""extendedTimeOut"": ""2000"",
                    ""showEasing"": ""swing"",
                    ""hideEasing"": ""linear"",
                    ""showMethod"": ""fadeIn"",
                    ""hideMethod"": ""fadeOut""
                }
            }
            if ($(""#verifyJs"").length) {
                Command: toastr[""success""](""Please verify your email"")

                toastr.options = {
                    ""closeButton"": false,
                    ""debug"": false,
                    ""newestOnTop"": fals");
                WriteLiteral(@"e,
                    ""progressBar"": false,
                    ""positionClass"": ""toast-top-right"",
                    ""preventDuplicates"": false,
                    ""onclick"": null,
                    ""showDuration"": ""300"",
                    ""hideDuration"": ""1000"",
                    ""timeOut"": ""7000"",
                    ""extendedTimeOut"": ""2000"",
                    ""showEasing"": ""swing"",
                    ""hideEasing"": ""linear"",
                    ""showMethod"": ""fadeIn"",
                    ""hideMethod"": ""fadeOut""
                }
            }
            if ($(""#verifiedJs"").length) {
                Command: toastr[""success""](""Your email has been verified"")

                toastr.options = {
                    ""closeButton"": false,
                    ""debug"": false,
                    ""newestOnTop"": false,
                    ""progressBar"": false,
                    ""positionClass"": ""toast-top-right"",
                    ""preventDuplicates"": false,
             ");
                WriteLiteral(@"       ""onclick"": null,
                    ""showDuration"": ""300"",
                    ""hideDuration"": ""1000"",
                    ""timeOut"": ""7000"",
                    ""extendedTimeOut"": ""2000"",
                    ""showEasing"": ""swing"",
                    ""hideEasing"": ""linear"",
                    ""showMethod"": ""fadeIn"",
                    ""hideMethod"": ""fadeOut""
                }
            }
            if ($(""#bookingJs"").length) {
                Command: toastr[""success""](""Reservation completed successfully"")

                toastr.options = {
                    ""closeButton"": false,
                    ""debug"": false,
                    ""newestOnTop"": false,
                    ""progressBar"": false,
                    ""positionClass"": ""toast-top-right"",
                    ""preventDuplicates"": false,
                    ""onclick"": null,
                    ""showDuration"": ""300"",
                    ""hideDuration"": ""1000"",
                    ""timeOut"": ""7000"",
       ");
                WriteLiteral(@"             ""extendedTimeOut"": ""2000"",
                    ""showEasing"": ""swing"",
                    ""hideEasing"": ""linear"",
                    ""showMethod"": ""fadeIn"",
                    ""hideMethod"": ""fadeOut""
                }
            }
             if ($(""#editJs"").length) {
                Command: toastr[""info""](""The operation was completed successfully"")

                toastr.options = {
                    ""closeButton"": false,
                    ""debug"": false,
                    ""newestOnTop"": false,
                    ""progressBar"": false,
                    ""positionClass"": ""toast-top-left"",
                    ""preventDuplicates"": false,
                    ""onclick"": null,
                    ""showDuration"": ""300"",
                    ""hideDuration"": ""1000"",
                    ""timeOut"": ""5000"",
                    ""extendedTimeOut"": ""1000"",
                    ""showEasing"": ""swing"",
                    ""hideEasing"": ""linear"",
                    ""showMethod");
                WriteLiteral("\": \"fadeIn\",\r\n                    \"hideMethod\": \"fadeOut\"\r\n                }\r\n            }\r\n        })\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
