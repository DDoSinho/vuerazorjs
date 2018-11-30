using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueRazorJs.Framework.VueRazorTable;

namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-table-header", ParentTag = "vue-razor-table-column")]
    public class VueRazorTableHeaderTagHelper : TagHelper
    {
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var vueRazorTable = (Table)context.Items[typeof(VueRazorTableTagHelper)];
            var columnContext = vueRazorTable.Columns[vueRazorTable.Columns.Count - 1];

            columnContext.HeaderContent = new HeaderContent()
            {
                Content = childContent,
                CssClasses = context.AllAttributes.Where(a => a.Name == "class").Select(a => a.Value.ToString()).FirstOrDefault()
            };

            output.SuppressOutput();
        }
    }
}
