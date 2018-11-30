using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueRazorJs.Framework.VueRazorTable;

namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-table-paginator", Attributes = "[count],[pagesize],[url]", ParentTag = "vue-razor-table")]
    public class VueRazorTablePaginatorTagHelper : TagHelper
    {
        [HtmlAttributeName("count")]
        public int Count { get; set; }

        [HtmlAttributeName("pagesize")]
        public int PageSize { get; set; }

        [HtmlAttributeName("url")]
        public string Url { get; set; }

        [HtmlAttributeName("position")]
        public Position PaginatorPosition { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "vue-razor-table-paginator");
            output.Attributes.Add("url", Url);

            if(this.Count > 0)
            {
                if(PageSize <=0)
                {
                    PageSize = 10;
                }

                var liBuilder = new StringBuilder($"<div class='vue-razor-table-paginator' url='{Url}' style='display:inherit'>");

                double count = Count;
                double pageSize = PageSize;

                double value = count / pageSize;
                int numberOfPages = (int)Math.Ceiling(value);

                if (numberOfPages == 1)
                {
                    liBuilder.Append($"<li class='page-item'><a class='page-link'>1</a></li>");
                }
                else
                {
                    for(int i = 0; i < numberOfPages; i++)
                        liBuilder.Append($"<li class='page-item'><a class='page-link page-index' v-on:click='movePage({i})'>{i+1}</a></li>");
                }

                var htmlBuilder = new StringBuilder($"<nav><ul class='pagination'>{liBuilder.ToString()}</ul></nav>");
                htmlBuilder.Append("</div>");

                var vueRazorTable = (Table)context.Items[typeof(VueRazorTableTagHelper)];
                vueRazorTable.Paginator = new VueRazorPaginator()
                {
                    PaginatorHtmlString = new HtmlString(htmlBuilder.ToString()),
                    Count = this.Count,
                    PageSize = this.PageSize,
                    Url = this.Url,
                    PaginatorPosition = this.PaginatorPosition
                };

                output.SuppressOutput();
            }
            else
            {
                //error handling
            }
        }
    }
}
