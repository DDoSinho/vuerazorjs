using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueRazorJs.Framework.VueRazorTable;

namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-table-content", ParentTag = "vue-razor-table-column")]
    public class VueRazorTableContentTagHelper : TagHelper
    {
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var vueRazorTable = (Table)context.Items[typeof(VueRazorTableTagHelper)];
            var columnContext = vueRazorTable.Columns[vueRazorTable.Columns.Count - 1];

            columnContext.RowContent = new RowContent()
            {
                Content = childContent,
                CssClasses = context.AllAttributes.Where(a => a.Name == "class").Select(a => a.Value.ToString()).FirstOrDefault()
            };

            output.SuppressOutput();
        }
    }
}
