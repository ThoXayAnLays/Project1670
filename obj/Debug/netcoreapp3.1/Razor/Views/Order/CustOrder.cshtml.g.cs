#pragma checksum "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc729f425c9efb3fe482561567fd8b1781f00e20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_CustOrder), @"mvc.1.0.view", @"/Views/Order/CustOrder.cshtml")]
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
#line 1 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\_ViewImports.cshtml"
using Project1670;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\_ViewImports.cshtml"
using Project1670.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc729f425c9efb3fe482561567fd8b1781f00e20", @"/Views/Order/CustOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8df05a91b5c5f0571e176b1d4fd66c7befd6eb4", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Order_CustOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Book", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
  
    Layout = "CustomerLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
 if (Model.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4 class=\"text text-danger text-center\"> No book found !</h4>\r\n");
#nullable restore
#line 10 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container text-center"">
    <table class=""table table-bordered"">
        <tr style=""background-color: cornflowerblue"">
            <th>Customer Email</th>
            <th>Book Title</th>
            <th>Quantity</th>
            <th>Total Price</th>
            <th>Date</th>
            <th>Image</th>
        </tr>
");
#nullable restore
#line 21 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
         foreach (var order in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
               Write(order.UserEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 26 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
                  
                    for (int i = 0; i < ViewBag.Books.Count; i++)
                    {
                        if (order.BookId == ViewBag.Books[i].Id)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><text>");
#nullable restore
#line 31 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
                                 Write(ViewBag.Books[i].Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</text></td>\r\n");
#nullable restore
#line 32 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
                        }
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 35 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
               Write(order.OrderQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 36 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
               Write(order.OrderPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
               Write(order.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc729f425c9efb3fe482561567fd8b1781f00e207216", async() => {
                WriteLiteral("\r\n                        <img");
                BeginWriteAttribute("src", " src=\"", 1240, "\"", 1263, 1);
#nullable restore
#line 40 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
WriteAttributeValue("", 1246, order.Book.Image, 1246, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"100\" height=\"100\" />\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"
                                                                   WriteLiteral(order.BookId);

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
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 44 "C:\Users\NNT.Koala\OneDrive\Tài liệu\GitHub\Project1670\Views\Order\CustOrder.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
