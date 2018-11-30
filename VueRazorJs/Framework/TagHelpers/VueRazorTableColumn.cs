using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueRazorJs.Framework.VueRazorTable;

namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-table-column", ParentTag = "vue-razor-table", Attributes ="for")]
    [RestrictChildren("vue-razor-table-header", new string[] { "vue-razor-table-content" })]
    public class VueRazorTableColumn : TagHelper
    {
        [HtmlAttributeName("for")]
        public string For { get; set; }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var vueRazorTable = (Table)context.Items[typeof(VueRazorTableTagHelper)];
            vueRazorTable.Columns.Add(new ColumnContext()
            {
                For = this.For
            });

            await output.GetChildContentAsync();

            output.SuppressOutput();
        }
    }
}
