using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-render-table", ParentTag = "vue-razor-app")]
    public class VueRazorRenderTable : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add(new TagHelperAttribute("id", "rendervuerazortable"));
        }
    }
}
