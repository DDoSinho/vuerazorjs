using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-table-paginator", Attributes = "count")]
    public class VueRazorTablePaginatorTagHelper : TagHelper
    {
        [HtmlAttributeName("count")]
        public int Count { get; set; }

        [HtmlAttributeName("pagesize")]
        public int PageSize { get; set; }

        [HtmlAttributeName("url")]
        public string Url { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "vue-razor-table-paginator");
            output.Attributes.Add("url", Url);

            if(this.Count > 0)
            {
                if(PageSize == 0)
                {
                    PageSize = 10;
                }

                var liBuilder = new StringBuilder();

                int numberOfPages = (Count / PageSize);

               

                if (numberOfPages == 1)
                {
                    liBuilder.Append($"<li class='page-item'><a class='page-link' href='#'>1</a></li>");
                }
                else
                {
                    for(int i = 0; i < numberOfPages; i++)
                        liBuilder.Append($"<li class='page-item'><a class='page-link page-index' href='#' v-on:click='movePage({i})'>{i+1}</a></li>");
                }

                var htmlBuilder = new StringBuilder($"<nav><ul class='pagination'>{liBuilder.ToString()}</ul></nav>");

                output.Content.AppendHtml(htmlBuilder.ToString());
            }
            else
            {
                //error handling
            }
        }
    }
}
